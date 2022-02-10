function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let rowElements = document.querySelectorAll('.container tr');
      let searchText = document.getElementById('searchField').value;

      for (const rowElement of rowElements) {
          if (rowElement.textContent.includes(searchText) && searchText !== '') {
              rowElement.classList.add('select')
          } else {
            rowElement.classList.remove('select')
          }
      }
   }
}