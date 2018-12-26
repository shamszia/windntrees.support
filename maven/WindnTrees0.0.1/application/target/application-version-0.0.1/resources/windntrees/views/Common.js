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

/// <summary>Key value pairs function construct definition.</summary>
function OptionItem(key, val) {
    var instance = this;
    
    /// <summary>Key</summary>
    instance.key = key;
    
    /// <summary>Value</summary>
    instance.val = val;
}

/// <summary>Error object representation function construct definition.</summary>
function ErrorItem(data)
{
    var instance = this;
    
    /// <summary>Error field.</summary>
    instance.errField = data.field;
    
    /// <summary>Error message.</summary>
    instance.errMessage = data.defaultMessage;
}