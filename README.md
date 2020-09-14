# TriangleVerticesWebAPI

This Web API allows the user to get information 2 different ways:

 1 - Get coordinates of a triangle when supplying the row and the column. The row must be a letter between A-F and the column must be a number between 1-12 (for this specific implementation). The response will return a string of coordinates separated by commas (ie 40,50,40,40,50,50) that follow this pattern (V1x, V1y, V2x, V2y, V3x, V3y). V1 will always be the vertex at the hypotenuse of the triangle. V2 will be the top vertex, and V3 will be the bottom vertex.
 
 
 2 - Get the alpha row and number column of a triangle when appropriate string list of coordinates is supplied. The vertices parameter needs to follow the same pattern as listed above, meaning the vertex at the hypotenuse is listed first (V1x, V1y), followed by the vertex at the top of the triangle (V2x, V2y) and finally the vertex at the bottom of the triangle (V3x, V3y). This needs to be passed in as a full string with each coordinate separated by a comma and/or space (ie 40,50,40,40,50,50).
 
 The Web API is self-hosted in a console app for ease of testing. You should be able to run the project which will fire up the self-hosting in the console, then you can use Postman or any other similar tool to test the API, or navigate to TriangleVertices.html using "view in browser" (if you are running Visual Studio) to test using a very simple UI. 
 
 the url to use to test from Postman is this: http://localhost:51634/api/Triangle/A/5                 (for getting triangle coordinates)
                                          OR: http://localhost:51634/api/Triangle/40,50,40,40,50,50   (for getting triangle row and column)
                                          
                                          
