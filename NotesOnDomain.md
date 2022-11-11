# Issues found when trying to implement specified data model

- Shift Entity has no connections
- ClientId field in Category class seems very out of place...
- OrderProduct class contains RestaurantOrder class that doesnt exist but the connection is correct

- Location has Client list. Knowing all clients of a location does not seem beneficial nor realistic
- Order has a single payment attached to it. What if the order is paid in parts?
- How does client differ from customer?
- Currently Product has Discount and Category properties. I think Discount should have a property of which products it applies to. Same goes for Category
- Service also has a Category property.
