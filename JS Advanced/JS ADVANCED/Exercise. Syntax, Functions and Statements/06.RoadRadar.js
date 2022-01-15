function roadRadar(speed, area) {
    
    function CheckIfIsInSpeedLimit(limit) {
        
        let result = '';
        let difference = speed - limit;
        let status = '';

        if (difference <= 0) {
            return `Driving ${speed} km/h in a ${limit} zone`;
        } else if (difference <= 20) {
            status = 'speeding';
        } else if (difference <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        
        return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`;
    }

    let output = '';

    switch (area) {
        case 'motorway':
            output = CheckIfIsInSpeedLimit(130);
            break;
        case 'interstate':
            output = CheckIfIsInSpeedLimit(90);
            break;
            case 'city':
            output = CheckIfIsInSpeedLimit(50);
            break;
        case 'residential':
            output = CheckIfIsInSpeedLimit(20);
            break;
        default:
            break;
    }

    console.log(output);
}