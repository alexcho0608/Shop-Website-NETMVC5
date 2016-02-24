# MVC Shop Site

# My website
> I decided to create a website for online shopping for electronic machinery. My website consists of a home page, listing the items by category. 

>Products page where a user can browse through the products and filter them by category or something else. 

>Product Details page, where a user can put an item in a shopping cart if he wants to.

>Cart page, where he can make the order.

>Administrator panel, where the admins can add or edit Items in the site.

# Technologies

>For the creation of the website I am using the Razor View Engine for rendering the html pages, Entity Framework for managing the database, stored on an SQL Server. For managing the different user roles, I use the AspNet Identity framework. To make sure that a third party application doesn't send a request on behalf of a logged in user, I have put an AntiForgeryTokenValidator in the site. 

>For better testing, I have used the repositort pattern for accessing the database.