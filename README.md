# Welcome Contact API 🤩
This API serves to you Contact operations such as list, add, update, delete. 

## How to Use
You can clone this repository and you can open to visual studio and compile. 

## How to Test
You can test on [Swagger Page](https://huseyinscontractapi.herokuapp.com/swagger/index.html)
### Explain EndPoints: 
- HttpGet api/Contact : You can get your contact list according to your owner id. You can test this endpoint with ownerId : **4**
- HttpGet /api/Contact/{ownerId}/{key}/{value} : You can search contact in your list according to your owner id, key such as **name, phone, email, or address**, and value. This endpoint serves you a model that contains some information such as id, name.
Then you can use this response id other endpoints like update or delete. 
- HttpPost api/Contact : You can add new contact int list.
- HttpUpdate api/Contact : You can update your some contact. You need update request model so you can search your contact with search endpoint. Then with search endpoint response, you can update this response in update endpoint.
- HttpDelete api/Contact : You can delete your some contact. You need an id number which will delete object, so you can search your contact with search endpoint. Then with search endpoint response, you can delete this response id in delete endpoint.

