function cook(numberString, o1, o2, o3, o4, o5) {
  
    let number = Number(numberString);
    
    function doOperation(operation) {
        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;
            default:
                break;
        }
    }

    doOperation(o1);
    console.log(number);
    
    doOperation(o2);
    console.log(number);

    doOperation(o3);
    console.log(number);

    doOperation(o4);
    console.log(number);

    doOperation(o5);
    console.log(number);
}