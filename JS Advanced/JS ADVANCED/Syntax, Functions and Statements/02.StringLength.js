function stringLength(str1, str2, str3) {
    let len1 = str1.length;
    let len2 = str2.length;
    let len3 = str3.length;

    console.log(len1 + len2 + len3);

    let result = (len1 + len2 + len3) / 3;
    console.log(Math.floor(result));
}