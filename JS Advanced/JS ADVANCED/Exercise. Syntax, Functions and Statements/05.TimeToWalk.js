function timeToWalk(steps, oneStepInMeters, speedInKmPerHour) {

    let lengthInMeters = steps * oneStepInMeters;
    let speedInMetersPerSecond = speedInKmPerHour * 1000 / 60;

    let extraTime = Math.floor(lengthInMeters / 500);
    let timeInMinutes = lengthInMeters / speedInMetersPerSecond + extraTime;


    let hours = Math.floor(timeInMinutes / 60).toString().padStart(2, '0');
    let minutes = Math.floor(timeInMinutes - (hours * 60)).toString().padStart(2, '0');
    let seconds = Math.ceil((timeInMinutes - (hours * 60) - minutes) * 60).toString().padStart(2, '0');

    console.log(`${hours.toString().padStart(2, '0')}:${minutes}:${seconds}`);
}