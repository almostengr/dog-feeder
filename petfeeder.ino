// https://www.arduino.cc/reference/en/



const int screenButtonPin = 4;
const int actionButtonPin = 5;
const int motorPin = 10;
const int ledLampPin = 14;

 unsigned long lastFeedScreenInterval = secondsToMilliseconds(120);

unsigned long lastFeedTime = 0;
unsigned long lastButtonPressTime = 0;
unsigned int currentScreenNumber = 0;

// state to represent screen that is being displayed
// transition to represent the phase to go from

long secondsToMilliseconds(long seconds){
  return seconds * 60 * 1000;
}

void setup() {
  pinMode(screenButtonPin, INPUT);
  pinMode(actionButtonPin, INPUT);
  // lcd display
  pinMode(motorPin, OUTPUT);
  pinMode(ledLampPin, OUTPUT); 
  
  // display message on LCD about software and version
}

void loop() {
  if (currentScreenNumber <= 0 || currentScreenNumber > 1)
  {
    currentScreenNumber = 1;
  }
  
  screenButtonState = digitalRead(screenButtonPin); // check button 1 state 
  
  if (screenButtonState == HIGH) {
    // if option screen, then save data
    // go to next screen
  }
  
  // check button 2 state 
  
  // update display 
  
  // 
}

void GoToHomeScreen() {
  unsigned long currentTime = millis();
  
  if ((currentTime - lastButtonPressTime) >= lastFeedScreenInterval){
    lastButtonPressTime = currentTime;
    currentScreenNumber = 1;
  }
}
