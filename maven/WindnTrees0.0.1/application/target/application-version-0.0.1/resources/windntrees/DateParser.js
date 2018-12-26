/*  Copyright [2018] [Invincible Technologies]
 *  
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *    
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/// <summary>Adds support for localized date and time resolution.</summary>
function DateParser() {
    var instance = Object.create({});

    /// <summary>Extracts date time value in milliseconds with support of following date time format /Date("YYYY-MM-DDTHH:MM:SS")/.</summary>
    instance.parseMilliSeconds = function (value) {

        if (value !== null && value !== undefined) {

            if (typeof (value) === "string") {

                if (value.startsWith("/Date(") && value.endsWith("/")) {

                    var milliseconds = value.replace("/Date(", "");
                    milliseconds = milliseconds.replace("/", "");

                    if (milliseconds.indexOf("+") > 0) {

                        milliseconds = milliseconds.substr(0, milliseconds.indexOf("+"));
                    }

                    if (milliseconds.indexOf("-") > 0) {

                        milliseconds = milliseconds.substr(0, milliseconds.indexOf("-"));
                    }

                    return parseInt(milliseconds);
                }
                else if (value.indexOf("T") > 0) {

                    //2018-07-24T08:28:24 will be parsed in UTC time period
                    //get milliseconds
                    return new Date(value).valueOf();
                }
            }
        }
        return value;
    };

    /// <summary>Gets localized date time instance from following date time  format /Date("YYYY-MM-DDTHH:MM:SS")/.</summary>
    instance.parseDate = function (value, local) {

        var milliSeconds = instance.parseMilliSeconds(value);

        if (typeof (milliSeconds) === "string") {

            return value;

        } else {

            if (local) {

                return instance.getLocalTime(milliSeconds);
            } else {

                return new Date(milliSeconds);
            }
        }
    };

    /// <summary>Gets local date time instance represented in milliseconds since 1970.</summary>
    instance.getLocalTime = function (milliseconds, response) {

        if (milliseconds !== null && milliseconds !== undefined) {

            //offset in minutes
            var offset = new Date().getTimezoneOffset();
            offset = (offset * 60); // get offset in minutes
            offset = (offset * 1000); // get offset in milliseconds

            var newTime = milliseconds;

            if (offset > 0) {

                //now subtract offset to get local time milliseconds.
                newTime -= Math.abs(offset);
            }
            else {
                //now add offset to get local time milliseconds.
                newTime += Math.abs(offset);
            }

            return new Date(newTime);
        }

        return new Date();
    };

    return instance;
}
