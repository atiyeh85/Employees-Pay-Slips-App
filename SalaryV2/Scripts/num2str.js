﻿// Developed By Ahmad Ahmadi
// Email : Hakan648@yahoo.com
// Web : DeveloperTeam.tk

var s_0_9 = new Array('صفر', 'یک', 'دو', 'سه', 'چهار', 'پنج', 'شش', 'هفت', 'هشت', 'نه');
var s_10_19 = new Array('ده', 'یازده', 'دوازده', 'سیزده', 'چهارده', 'پانزده', 'شانزده', 'هفده', 'هجده', 'نوزده');
var s_20_90 = new Array('بیست', 'سی', 'چهل', 'پنجاه', 'شصت', 'هفتاد', 'هشتاد', 'نود');
var s_100_900 = new Array('صد', 'دویست', 'سیصد', 'چهارصد', 'پانصد', 'ششصد', 'هفتصد', 'هشتصد', 'نهصد');
var s_Parts = new Array('هزار', 'میلیون', 'میلیارد', 'تريليون');
var splitter = " و ";
var veryBig = "تعریف نشده";
var negative = "منفی";

function getPart(numberIn3) {
    if (numberIn3.length > 3) {
        return "";
    }

    var number = numberIn3.toString();

    switch (number.length) {
        case 1:
            number = "00" + number;
            break;
        case 2:
            number = "0" + number;
            break;
    }

    var outString = "";

    var n1 = parseInt(number.substr(0, 1));
    var n2 = parseInt(number.substr(1, 1));
    var n3 = parseInt(number.substr(2, 1));

    if (n1 != 0) {
        switch (n2) {
            case 0:
                if (n3 != 0) {
                    outString = s_100_900[n1 - 1] + splitter + s_0_9[n3];
                }
                else {
                    outString = s_100_900[n1 - 1];
                };
                break;
            case 1:
                outString = s_100_900[n1 - 1] + splitter + s_10_19[n3];
                break;
            default:
                if (n3 != 0) {
                    outString = s_100_900[n1 - 1] + splitter + s_20_90[n2 - 2] + splitter + s_0_9[n3];
                }
                else {
                    outString = s_100_900[n1 - 1] + splitter + s_20_90[n2 - 2];
                }
        }
    }
    else {
        switch (n2) {
            case 0:
                if (n3 != 0) {
                    outString = s_0_9[n3];
                }
                else {
                    outString = "";
                }
                break;
            case 1:
                outString = s_10_19[n3];
                break;
            default:
                if (n3 != 0) {
                    outString = s_20_90[n2 - 2] + splitter + s_0_9[n3];
                }
                else {
                    outString = s_20_90[n2 - 2];
                }
        }
    };

    return outString;
}

function convertNumberToString(inputNumber) {
    var tempNumber = Math.abs(inputNumber).toString();
            
    if (tempNumber.length == 0) {
        return "";
    }

    if (tempNumber == 0)
        return s_0_9[0];

    var partCount = Math.ceil((parseInt(tempNumber).toString().length / 3), 1);

    if (s_Parts.length < partCount)
        return veryBig;

    var partFullString = new Array();

    for (var i = 0; i < partCount; i++) {
        var numberLength3;

        var lengthToSelectFirtPart;
        if (i == 0) {
            lengthToSelectFirtPart = tempNumber.length - ((partCount - 1) * 3);
            numberLength3 = tempNumber.substr((i * 3), lengthToSelectFirtPart);
        }
        else {
            numberLength3 = tempNumber.substr(lengthToSelectFirtPart + ((i - 1) * 3), 3);
        }

        var partInWord = getPart(numberLength3);

        var partIndex = (partCount - 2 - i);
        var partPreFix = s_Parts[partIndex];

        if (i == partCount - 1) {
            partPreFix = "";
        }

        if (i == 0) {
            if (partInWord != "") {
                partFullString[i] = partInWord + " " + partPreFix;
            }
            else {
                partFullString[i] = "";
            }
        }
        else {
            if (partFullString[i - 1] != "") {
                if (partInWord != "") {
                    partFullString[i] = splitter + partInWord + " " + partPreFix;
                }
                else {
                    partFullString[i] = "";
                }
            }
            else {
                if (partInWord != "") {
                    partFullString[i] = splitter + partInWord + " " + partPreFix;
                }
                else {
                    partFullString[i] = "";
                }
            }
        }
    }

    var outString = "";

    for (var i = 0; i < partFullString.length; i++) {
        outString += partFullString[i];
    }

    if (inputNumber.substr(0, 1) == "-") {
        outString = negative + " " + outString;
    }

    return outString;
}