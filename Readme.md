# Skinet

![Home Page](API\Content\images\readme\homePage.png)
### Description
###### The concept of the online store. 
###### The visitor has the following features: view all products, go to a page and view detailed information about the product, sort products, add them to the cart, register, log in, place orders followed by payment card, view orders.
###### I made the site based on the course https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular/. 
###### In the course the payment system was Stripe. Since the Stripe payment system is not available in my country, I used LiqPay.

#### How to Use
![Shop Page](API\Content\images\readme\shopPage.png)
###### To add an item to cart you need to hover over it and click on the button with the cart image. This can also be done on the page with information about the item. To go to it hover your mouse over the item and press View.
![Order Page](API\Content\images\readme\basketPage.png)
###### If you want to go to the cart page, either click on the cart image or click in the upper right corner on the inscription "Welcome [Name]", and then select "View Basket" in the drop-down window.
###### In the cart you can view the selected purchases, increase or decrease the number of certain items, delete an item.
![Order2 Page](API\Content\images\readme\basketPage2.png)
###### Also on this page you can view order summery and go to the payment page. To do this you need to click "Proceed checkout". 
###### To purchase items you must do the following:
###### 1. Enter your address
![Address Page](API\Content\images\readme\addressPage.png)
###### 2. Choose a delivery method
![Delivery Page](API\Content\images\readme\deliveryPage.png)
###### 3. Riview your order
###### 4. Enter your card details
![Payment Page](API\Content\images\readme\paymentPage.png)
###### If payment is successful you will be redirected to the page notifying you about it.
![Success Page](API\Content\images\readme\success.png)
###### After that you can go to the page with your orders. To do this, click on in the upper right corner on the inscription "Welcome [Name]", and then select "View Orders" in the drop-down window.
![Orders Page](API\Content\images\readme\orders.png)
###### By clicking on the selected order you can go to a page with detailed information about it.
#### Progect setup
###### docker-compose up --detach
###### cd api
###### dotnet restore
###### dotnet watch
