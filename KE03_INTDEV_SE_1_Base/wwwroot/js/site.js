//function addToCart(productId, name, price) {
//    let cart = JSON.parse(localStorage.getItem('cart')) || [];

//    // Voeg product toe
//    cart.push({ id: productId, name: name, price: price });
//    localStorage.setItem('cart', JSON.stringify(cart));

//    // Tel aantal en totaalbedrag op
//    const totalItems = cart.length;


//    // Toon gegevens in modal
//    const body = document.getElementById('cartModalBody');
//    body.innerText = `Je hebt nu ${totalItems} product${totalItems === 1 ? '' : 'en'} in je winkelmandje.`;

//    // Toon modal
//    const modal = new bootstrap.Modal(document.getElementById('cartModal'));
//    modal.show();
//}

function addToCart(productId, name, price) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];

    // Zoek of het product al in de winkelmand zit
    const existingProduct = cart.find(p => p.id === productId);

    if (existingProduct) {
        // Verhoog de hoeveelheid
        existingProduct.quantity += 1;
    } else {
        // Voeg nieuw product toe met quantity 1
        cart.push({ id: productId, quantity: 1 });
    }

    // Sla het winkelmandje weer op
    localStorage.setItem('cart', JSON.stringify(cart));

    // Bereken totaal aantal producten (optellen van quantity)
    const totalItems = cart.reduce((sum, p) => sum + p.quantity, 0);

    // Update de modal tekst
    const body = document.getElementById('cartModalBody');
    body.innerText = `Je hebt nu ${totalItems} product${totalItems === 1 ? '' : 'en'} in je winkelmandje.`;

    // Toon de modal
    const modal = new bootstrap.Modal(document.getElementById('cartModal'));
    modal.show();
}
