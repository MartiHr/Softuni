function manageTickets(ticketInfoArr, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let sortedTickets = ticketInfoArr
        .map(x => x.split('|'))
        .map(x => new Ticket(x[0], Number(x[1]), x[2]))
        .sort((a, b) => {
            if (typeof(a)[sortingCriteria] === 'number') {
                return a[sortingCriteria] - b[sortingCriteria];
            }

            return a[sortingCriteria].localeCompare(b[sortingCriteria]);
        });

    return sortedTickets;
}