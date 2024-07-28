document.addEventListener("DOMContentLoaded", () => {
    const userLoginForm = document.getElementById("userLoginForm");
    const userRegistrationForm = document.getElementById("userRegistrationForm");
    const productsList = document.getElementById("productsList");
    const cartList = document.getElementById("cartList");

    // User Registration
    if (userRegistrationForm) {
        userRegistrationForm.addEventListener("submit", async (e) => {
            e.preventDefault();
            const username = document.getElementById("registerUsername").value;
            const password = document.getElementById("registerPassword").value;

            const response = await fetch("https://localhost:7124/api/users/register", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ username, password })
            });

            if (response.ok) {
                alert("Registration successful! Please log in.");
                window.location.href = "index.html"; // Redirect to login page after registration
            } else {
                alert("Registration failed. Please try again.");
            }
        });
    }

    // User Login
    if (userLoginForm) {
        userLoginForm.addEventListener("submit", async (e) => {
            e.preventDefault();
            const username = document.getElementById("username").value;
            const password = document.getElementById("password").value;

            const response = await fetch("https://localhost:7124/api/users/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ username, password })
            });

            if (response.ok) {
                const data = await response.json();
                localStorage.setItem("userToken", data.token);
                localStorage.setItem("userId", data.userId);
                window.location.href = "products.html";
            } else {
                alert("User login failed. Please check your credentials.");
            }
        });
    }

    // Fetch and Display Products
    if (productsList) {
        fetchProducts();

        async function fetchProducts() {
            const response = await fetch("https://localhost:7124/api/products", {
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem("userToken")}`
                }
            });

            if (response.ok) {
                const products = await response.json();
                productsList.innerHTML = products.map(product => `
                    <div class="product-card">
                        <img src="${product.image}" alt="${product.name}">
                        <div class="product-details">
                            <h2>${product.name}</h2>
                            <p>${product.description}</p>
                            <p>Price: $${product.price}</p>
                        </div>
                        <div class="product-actions">
                            <button onclick="addToCart(${product.productId})">Add to Cart</button>
                            <a href="product-details.html?id=${product.productId}">Details</a>
                        </div>
                    </div>
                `).join("");
            } else {
                alert("Failed to fetch products.");
            }
        }
    }

    // Add to Cart
    window.addToCart = async function (productId) {
        const userId = localStorage.getItem("userId");

        const response = await fetch("https://localhost:7124/api/carts", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("userToken")}`
            },
            body: JSON.stringify({ userId, productId, quantity: 1 })
        });

        if (response.ok) {
            alert("Product added to cart.");
            window.location.href = "cart.html";
        } else {
            alert("Failed to add product to cart.");
        }
    };

    // Fetch and Display Cart
    if (cartList) {
        fetchCart();

        async function fetchCart() {
            const userId = localStorage.getItem("userId");

            const response = await fetch(`https://localhost:7124/api/carts/${userId}`, {
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${localStorage.getItem("userToken")}`
                }
            });

            if (response.ok) {
                const cartItems = await response.json();
                cartList.innerHTML = cartItems.map(item => `
                    <div class="cart-item">
                        <p>Product ID: ${item.productId}</p>
                        <p>Quantity: ${item.quantity}</p>
                    </div>
                `).join("");
            } else {
                alert("Failed to fetch cart.");
            }
        }
    }
});
