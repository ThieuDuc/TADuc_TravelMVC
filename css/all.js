function searchfun() {
    // Get the search input value
    const searchTerm = document.getElementById('#menu_search').value.toLowerCase();
    
    // Get all the product elements
    const products = document.querySelectorAll('.producter #sp');
  
    // Loop through the products and show/hide based on search term
    products.forEach(product => {
      const name = product.querySelector('h2').textContent.toLowerCase();
      if (name.includes(searchTerm)) {
        product.style.display = 'block';
      } else {
        product.style.display = 'none';
      }
    });
  }

  function showAll() {
    // Get all the product elements
    const products = document.querySelectorAll('.producter #sp');
  
    // Loop through the products and show them all
    products.forEach(product => {
      product.style.display = 'block';
    });
  }