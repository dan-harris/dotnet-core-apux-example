# dotnet-core-apux-example

This app was created using dotnet CLI 2.1.100.

## Run the API

To run this app via the dotnet CLI, simply clone the repo and run:

```
cd .\src\DotnetCoreApuxExample.Api\
dotnet watch run
```

## Test the API

The API has a few pre-canned actions. Sending any of the following to /api/v1 as JSON in the body of a POST call will work:

**PRODUCT_GET_BY_ID**

```javascript
{
	"type": "PRODUCT_GET_BY_ID",
	"payload": 3
}
```

**CART_ADD_PRODUCT**

```javascript
{
	"type": "CART_ADD_PRODUCT",
	"payload": 3
}
```

**CART_LIST_PRODUCTS**

```javascript
{
	"type": "CART_LIST_PRODUCTS",
	"payload": {}
}
```

**CART_REMOVE_PRODUCT**

```javascript
{
	"type": "CART_REMOVE_PRODUCT",
	"payload": 3
}
```
