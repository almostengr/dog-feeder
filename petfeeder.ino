// https://www.arduino.cc/reference/en/

#include <LiquidCrystal_I2C.h>

const int SCREEN_BUTTON_PIN = 4;
const int ACTION_BUTTON_PIN = 5;
const int MOTOR_PIN = 10;
const int LIGHT_PIN = 14;

const int OFF = 0;
const int ON = 1;

const int PUSHED = 1;

enum MOTOR_DIRECTION
{
  FORWARD,
  REVERSE,
  M_OFF,
};

enum DISPLAY
{
  D_VERSION,
  D_LAST_FEED,
  D_FEEDING,
  D_DURATION,
};

enum LIGHT
{
  L_ON,
  L_OFF
};

LiquidCrystal_I2C lcd_i2c(0x27, 16, 2); // I2C address 0x27, 16 column and 2 rows

void setup()
{
  pinMode(SCREEN_BUTTON_PIN, INPUT_PULLUP);
  pinMode(ACTION_BUTTON_PIN, INPUT_PULLUP);
  pinMode(MOTOR_PIN, OUTPUT);
  pinMode(LIGHT_PIN, OUTPUT);

  lcd_i2c.init();
  lcd_i2c.backlight();
}

unsigned long lastFeedTime = 0;
unsigned long lastButtonPressTime = 0;
DISPLAY displayState = D_VERSION;
LIGHT lightState = L_ON;
MOTOR_DIRECTION motorDirection = M_OFF;
unsigned int duration = 2;
bool actionButtonWasLow = false;
bool screenButtonWasLow = false;

void loop()
{
  unsigned long int currentTime = millis();

  displayScreen(currentTime);
  displayLight(currentTime);
}

void displayScreen(unsigned long int nowTime)
{
  float hoursAgo;
  switch (displayState)
  {
    case D_LAST_FEED:
      hoursAgo = (nowTime - lastFeedTime) / 3600000;
      lcdDisplayText("LAST FED", hoursAgo + " HOURS AGO");

      if (isScreenButtonPressed())
      {
        displayState = D_DURATION;
      }

      if (isActionButtonPressed()) {
        displayState = D_FEEDING;
      }
      break;

    case D_FEEDING:
      lcdDisplayText("FEEDING");

      // when feeding duration exceeds state change time
      break;


    case D_DURATION:
      lcdDisplayText(DURATION, duration);

      if (isScreenButtonPressed())
      {
        displayState = D_LAST_FEED;
        // save data
      }

      if (isActionButtonPressed())
      {
        duration++;
        if (duration > 9)
        {
          duration = 2;
        }
      }
      break;

    default:
      displayState = D_LAST_FEED;
      break;
  }
}

void displayLight(unsigned long int nowTime)
{
  switch (lightState)
  {
    case L_OFF:
      digitalWrite(LIGHT_PIN, OFF);

      if (isScreenButtonPressed() || isActionButtonPressed())
      {
        lightState = L_ON;
        lastButtonPressTime = nowTime;
      }
      break;

    default:
      digitalWrite(LIGHT_PIN, ON);

      if (nowTime - lastButtonPressTime >= 30000)
      {
        lightState = L_OFF;
      }
      break;
  }
}

void updateButtonPressTime(unsigned long int time)
{
  lastButtonPressTime = time;
}

bool isActionButtonPressed()
{
  // read the state of the pushbutton and set a flag if it is low:
  if (digitalRead(ACTION_BUTTON_PIN) == LOW)  {
    actionButtonWasLow = true;
    // return false;
  }

  //  return (digitalRead(ACTION_BUTTON_PIN) == PUSHED);
  // This if statement will only fire on the rising edge of the button input
  if (digitalRead(ACTION_BUTTON_PIN) == HIGH && actionButtonWasLow)  {
    actionButtonWasLow = false; // reset the button low flag
    return true;// Button event here
  }

  return false;
}

bool isScreenButtonPressed()
{
  //  return (digitalRead(SCREEN_BUTTON_PIN) == PUSHED);

  if (digitalRead(SCREEN_BUTTON_PIN) == LOW)  {
    screenButtonWasLow = true;    
  }

  // This if statement will only fire on the rising edge of the button input
  if (digitalRead(SCREEN_BUTTON_PIN) == HIGH && screenButtonWasLow)  {
    // reset the button low flag
    screenButtonWasLow = false;

    // Button event here
    return true;
  }

  return false;
}

void lcdDisplayText(String line1, String line2)
{
  lcd_i2c.setCursor(0, 0);
  lcd_i2c.print(line1);
  lcd_i2c.setCursor(0, 1);
  lcd_i2c.print(line2);
}
