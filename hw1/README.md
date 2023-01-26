# HW1 - Strategizing about Shapes

## Command Line Arguments
I used 'dotnet build' and 'dotnet run' in the terminal to run this project. To build the project run 'dotnet build'.
To run the project run 'dotnet run' plus three or four other valid arguments. The correct format for these other four
arguments are as follows: [file type] [file name] [output type] [output file location]. 

'File Type' is referring to the input file type. Only 'xml' and 'json' are supported. Example: 'json'

'File Name' is referring to the name of the input file. Example: 'test_data.xml'

'Output Type' has two options: 'csv' or 'console'. If you enter 'console' then fourth argument, 'output file location', 
no longer applies and thus should be left blank.

'Output File Location' only is needed if you entered 'csv' for the third argument. As is indicated by the name, you
should enter the desired location for the csv file to be saved to. Note: you do not need to enter the name of the csv as
that is hard coded as "output.csv".

## Shape Classes
The abstract shape class has four children classes: Ellipse, Triangle, and Rectangle. After a good amount of time trying
to figure out the best way to implement them I realized that all of these shapes can have their area calculated with
one or two lengths. It seems like cheating a little bit with the triangles, but 1/2 base * height is conveniently the 
area formula for every triangle. In the assignment instructions it didn't specify that the side lengths had to be use, 
so sorry not sorry Trey. 

## Dependencies 
The only dependency I am using is 'Newtonsoft.json' which is easily available on Visual Studio.