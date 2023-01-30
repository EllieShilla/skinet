# Skinet

![Home Page](https://user-images.githubusercontent.com/74963526/215532427-9f3bd616-9f78-4b7e-8225-461c8295318f.png)

### Description
###### The concept of the online store. 
###### The visitor has the following features: view all products, go to a page and view detailed information about the product, sort products, add them to the cart, register, log in, place orders followed by payment card, view orders.
###### I made the site based on the course https://www.udemy.com/course/learn-to-build-an-e-commerce-app-with-net-core-and-angular/. 
###### In the course the payment system was Stripe. Since the Stripe payment system is not available in my country, I used LiqPay.

#### How to Use

![Shop Page](https://user-images.githubusercontent.com/74963526/215532441-40f1fd85-4536-4009-83a5-7bc750b4f457.png)

###### To add an item to cart you need to hover over it and click on the button with the cart image. This can also be done on the page with information about the item. To go to it hover your mouse over the item and press View.
![Order Page](https://user-images.githubusercontent.com/74963526/215532452-e7d9f035-99a0-4276-858b-359d260eeefd.png)
###### If you want to go to the cart page, either click on the cart image or click in the upper right corner on the inscription "Welcome [Name]", and then select "View Basket" in the drop-down window.
###### In the cart you can view the selected purchases, increase or decrease the number of certain items, delete an item.
![Order2 Page](https://user-images.githubusercontent.com/74963526/215532455-7a51aba4-3e4a-448f-ab0b-2dc7fd386e97.png)
###### Also on this page you can view order summery and go to the payment page. To do this you need to click "Proceed checkout". 
###### To purchase items you must do the following:
###### 1. Enter your address
![Address Page](https://user-images.githubusercontent.com/74963526/215532449-17901d3a-9f3d-47de-8971-16243910462b.png)
###### 2. Choose a delivery method
![Delivery Page](https://user-images.githubusercontent.com/74963526/215532456-9ab7dafe-3612-4937-87f9-200b2a10c9d6.png)
###### 3. Riview your order
###### 4. Enter your card details
![Payment Page](https://user-images.githubusercontent.com/74963526/215532437-17b81422-6c56-442c-8f67-72b6257de904.png)
###### If payment is successful you will be redirected to the page notifying you about it.
![Success Page](https://user-images.githubusercontent.com/74963526/215532446-c1ca72cf-6cb1-41fb-ab00-9e41247f1abc.png)
###### After that you can go to the page with your orders. To do this, click on in the upper right corner on the inscription "Welcome [Name]", and then select "View Orders" in the drop-down window.
![Orders Page](https://user-images.githubusercontent.com/74963526/215532433-bc394292-83a5-4fe9-8e52-c20675dc1817.png)

###### By clicking on the selected order you can go to a page with detailed information about it.
#### Progect setup
###### docker-compose up --detach
###### cd api
###### dotnet restore
###### dotnet watch
