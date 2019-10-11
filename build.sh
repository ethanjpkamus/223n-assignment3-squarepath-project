#Author: Ethan

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile squarepathuserinterface.cs:"
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:squarepathuserinterface.dll squarepathuserinterface.cs

echo "Compile and link squarepathmain.cs:"
mcs -r:System -r:System.Windows.Forms -r:squarepathuserinterface.dll -out:squarepathmain.exe squarepathmain.cs

echo "Run the program Straight Line Travel"
./squarepathmain.exe

echo "The bash script has terminated."
