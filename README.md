# Async-Inn

## Author: Jordan Kidwell

## Visual
![ERD for Async Inn](assets/AsyncInnERD1.png)


## Explanation of Tables & Relationships:
-  *Hotel Table*:
   - This table contains the details for each one that includes name, city, state, address and phone number. 
   -It is identified with a int Primary Key "LocationID"
   - 1:1 relationship w/ LocationRoom table to identify which rooms are at which location.
- *HotelRoom Table*:
  - This table joins together the Composite Key using foreign keys for HotelID and RoomID in order to be able to store which of the rooms are at which location.
  - It contains information about the price and RoomNumber, these are unique to each specified location.
  - 1:1 relationship with Hotels and Rooms to create composite key
- *Layouts Table* 
  - This table stores the details for each room and also contain a primary key "RoomID", string for RoomName & Enum for the layout (number of rooms).
  - 1:1 relationship w/ both the HotelRooms table and the RoomAmenities table.
- *RoomAmenities Table*:
  - This is our Pure Join table that brings together the "LayoutID" from the RoomLayouts table & the "LayoutID" from Amenities Table.
  - It only 1:1 w/ rooms and amenities to create a connection between the two. 
- *Amenities Table*:
  - This table has information about the amenities. (ID and Name)
  - 1:Many w/ RoomAmenities table to conjoin together with the layouts so that multiple amenities can be added.