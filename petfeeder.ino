int lastFeedMs = 0;

const int screenButtonPin = 4;
const int actionButtonPin = 5;
const int motorPin = 10;
const int ledLampPin = 14;

void setup() {
  pinMode(screenButtonPin, INPUT);
  pinMode(actionButtonPin, INPUT);
  // lcd display
  pinMode(motorPin, OUTPUT);
  pinMode(ledLampPin, OUTPUT); 
}

void loop() {
  screenButtonState = digitalRead(screenButtonPin); // check button 1 state 
  
  if (screenButtonState == HIGH) {
    // do something
  }
  
  // check button 2 state 
  
  // update display 
  
  // 
}
