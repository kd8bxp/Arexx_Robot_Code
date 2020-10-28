/*
Copyright (c) 2019 LeRoy Miller

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses>

If you find this or any of my projects useful or enjoyable please support me.  
Anything I do get goes to buy more parts and make more/better projects.  
https://www.patreon.com/kd8bxp  
https://ko-fi.com/lfmiller  

https://github.com/kd8bxp
https://www.youtube.com/channel/UCP6Vh4hfyJF288MTaRAF36w  
https://kd8bxp.blogspot.com/  
*/

#include <Wire.h>
#include "src/LOLIN_I2C_MOTOR/LOLIN_I2C_MOTOR.h"

LOLIN_I2C_MOTOR motor; //I2C address 0x30

void setup() {
   while (motor.PRODUCT_ID != PRODUCT_ID_I2C_MOTOR) //wait motor shield ready.
  {
    motor.getInfo();
  }
  delay(2500);
motor.changeFreq(MOTOR_CH_BOTH, 1000); //Change A & B 's Frequency to 1000Hz.
motor.changeDuty(MOTOR_CH_BOTH, 100);
//Backward
motor.changeStatus(MOTOR_CH_A, MOTOR_STATUS_CW);
motor.changeStatus(MOTOR_CH_B, MOTOR_STATUS_CCW);
delay(1000);
motor.changeStatus(MOTOR_CH_BOTH, MOTOR_STATUS_STOP);
delay(500);
//forward
motor.changeStatus(MOTOR_CH_A, MOTOR_STATUS_CCW);
motor.changeStatus(MOTOR_CH_B, MOTOR_STATUS_CW);
delay(1000);
motor.changeStatus(MOTOR_CH_BOTH, MOTOR_STATUS_STOP);
delay(500);
}

void loop() {
  

}
