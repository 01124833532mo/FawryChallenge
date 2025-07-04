# Fawry E-Commerce Challenge Solution

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

## Overview

This repository contains my solution to the Fawry Quantum Internship Challenge, implementing an e-commerce system with product management, shopping cart functionality, and checkout processes in C#.

## Features Implemented

✔ **Product Management System**  
✔ **Shopping Cart Functionality**  
✔ **Checkout Process with Validation**  
✔ **Shipping Service Integration**  
✔ **Comprehensive Error Handling**

## Code Structure
```
FawryChallenge/
├── Interfaces/
│   ├── IExpirable.cs
│   └── IShippable.cs
├── Models/
│   ├── Products/
│   │   ├── Product.cs
│   │   ├── ExpirableProduct.cs
│   │   ├── NonExpirableProduct.cs
│   │   ├── ShippableProduct.cs
│   │   └── ShippableExpirableProduct.cs
│   ├── Cart.cs
│   ├── CartItem.cs
│   └── Customer.cs
├── Services/
│   ├── IShippingService.cs
│   ├── ShippingService.cs
│   └── CheckoutService.cs
└── Program.cs
```
## Getting Started

### Prerequisites

- .NET 8.0 or later
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/01124833532mo/FawryChallenge.git
   cd FawryChallenge
