
# MyWeatherAZApp
For this project I wanted to create an Azure function that would send me daily weather information to my email. 


## Things learned along the way

 OpenweatherApi is what I used to pull weather data, and they have two versions of their API 3.0 and 3.1 as of writing this 3.1 is not free and caused some confusion when testing 

 For the email part of this I wanted to use sendGrid to handle sending emails, however they have cracked down extremely hard on new user accounts and have made the process of verifying a new account almost impossible
 because of this I switch over to mailjet which has a free tier that allows for up to 200 emails a day. 

 Another issue I ran into with mailjet was the need for either a verified email or domain, luckily I still have my Steven-Dixon.com domain so it was pretty easy to add a text record and verify

 The simplest part of this project was creating the Azure function, as there is a ton of documentation and I have been studying for the AZ-204
 
 For the Email template part of things I opted to used handlebars, but I realize mailject offers a free templating service so this may be a better solution to reduce storage costs

 ## Final product

 ![First Email](https://drive.google.com/uc?id=1Hf5qmV3bdYgU8aoG5iWF9GvTDKNkJ7lT)
 
 It's not much to look at but this is final product!
