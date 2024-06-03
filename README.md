# TestAPI
Test Task:
- Implement a web api that would:
- Accept two pairs of doubles, representing a segment
- Search internal database and return a list of rectangles that interset the input segment by any of the edges
- Any ORM or raw SQL of a preference
- Storage format/schema can be of any preference
- Consider performance implications for large number of stored rectangles
- Unit/integration tests is a plus

To run the project it is needed to create a MS SQL database then run Database\SearchSegments.sql on the just created database
The script will create Segment table, stored procedure to search for suitable segments and fill the table with test data
To connect to database it is needed to change connection string in Controllers\SegmentController.cs
line 

using (var db = new DataClassesDataContext(@"Data Source=DESKTOP-8U3LNMG\SQLEXPRESS2017;Initial Catalog=TestAPI;Integrated Security=True"))

to some other correct string. or this connection string can be removed and then it is needed to change connection string in web.config

It is supposed to test by sending POST request with segment edges like this -
https://localhost:44373/API/segment/SearchSegment?x=5.5&y=16&x1=33.20&y1=40
