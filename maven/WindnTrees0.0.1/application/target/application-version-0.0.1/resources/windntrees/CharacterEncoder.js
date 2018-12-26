/// <summary>
/// Reforms unicode character string with appropriate coding characters compatible 
/// for displaying.
/// </summary>
function reformUniCodeString(options) {
    var instance = this;
    options = (options !== null && options !== undefined) ? options : {};

    /// <summary>
    /// Formats string value with appropriate characters for displaying.
    /// </summary>
    instance.formatString = function (value) {

        if (value.startsWith("&#x")) {

            //&#x6CC;&#x6C1; &#x62E;&#x627;&#x646;&#x6C1;
            var formattedString = value;

            //formats ' ' with unicode equivalent
            formattedString = formattedString.replace(/ /gi, "&#x020;");

            //formats &#x6CC in 0x6CC
            formattedString = formattedString.replace(/&#/gi, "0");
            //formats &#x6CC;&#x6C1; in 0x6CC,0x6C1,
            formattedString = formattedString.replace(/;/gi, ",");
            //removes 0x6CC,0x6C1, last ',' as 0x6CC,0x6C1
            formattedString = formattedString.substr(0, formattedString.length - 1);

            //resultant formatted string shoule be
            //0x6CC,0x6C1,0x020,0x62E,0x627,0x646,0x6C1
            var uniCodeStrings = formattedString.split(',');
            var uniCodes = [];

            for (var i = 0; i < uniCodeStrings.length; i++) {

                uniCodes.push(parseInt(uniCodeStrings[i]));
            }

            formattedString = String.fromCharCode.apply(this, uniCodes);

            return formattedString;
        }

        return value;
    };

    if (options.StringType !== null && options.StringType !== undefined) {

        if (options.StringType === "&#;") {

            return instance.formatString(options.value);
        }
    }
    else {
        //&#;

        return instance.formatString(options);
    }
}