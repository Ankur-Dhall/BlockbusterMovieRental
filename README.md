# Blockbuster Movie Rental

This is a web application made using Asp.Net MVC. This application is to be used at a video rental store. It uses Individual user authentication provided by identity framework. It provides 2 types of roles i.e, store manager and guests. Only Store Manager can add or remove new movies and other users can view only view movies available. Any logged in user can add or remove new customers. This application provides 2 features i.e, Renting and returning videos.

#### This is the home page of the application:
![Screenshot (4)](https://user-images.githubusercontent.com/42307111/87226674-f4fc6c80-c3b2-11ea-9c6f-93af1626c7ce.png)
#### When you click on customers tab you see all the users and their membership type:
![Screenshot (5)](https://user-images.githubusercontent.com/42307111/87226676-fb8ae400-c3b2-11ea-9dac-2c2486a2f3d9.png)
#### New customers can be added, edited and deleted:
![Screenshot (6)](https://user-images.githubusercontent.com/42307111/87226679-ffb70180-c3b2-11ea-9a15-87e6129f157c.png)
#### Since I logged-in as Admin(Store Manager Role), I get the option to add, remove or edit movies:
![Screenshot (7)](https://user-images.githubusercontent.com/42307111/87226683-03e31f00-c3b3-11ea-9d3e-9eb7fa2fc2bc.png)
### Edit movies:
![Screenshot (8)](https://user-images.githubusercontent.com/42307111/87226684-06de0f80-c3b3-11ea-9d20-c3f707b058d5.png)
#### Add new movies:
![Screenshot (9)](https://user-images.githubusercontent.com/42307111/87226686-0b0a2d00-c3b3-11ea-8e7a-74d06307baf7.png)
#### I have used twitter's Typeahead here for autocomplete feature. Only movies with stock>0 are shown here:
![Screenshot (10)](https://user-images.githubusercontent.com/42307111/87226688-0e9db400-c3b3-11ea-9247-d4d956ce5a74.png)
#### Multiple movies can be rented at once. Customer can even rent multiple copies of same movie at once if stock available:
![Screenshot (11)](https://user-images.githubusercontent.com/42307111/87226691-178e8580-c3b3-11ea-945b-8b40f404a8c9.png)
#### Both client side and server side validations are used in forms:
![Screenshot (12)](https://user-images.githubusercontent.com/42307111/87226698-2a08bf00-c3b3-11ea-86ec-4898dcc4ec82.png)
#### On successful return, cost of the rentals is calculated according to the rental period and discounts are also applied if customer has a membership:
![Screenshot (13)](https://user-images.githubusercontent.com/42307111/87226702-2d9c4600-c3b3-11ea-8617-c9b2cb655498.png)
