# Neuroph-Xamarin-Bindings-Desktop
Xamarin (C#) Bindings for Neuroph Framework Desktop Applications

# How To Generate Bindings
1. Download IKVM From [Here](https://sourceforge.net/projects/ikvm/files/latest/download?source=files) And Extract it to a Folder on PATH
2. Run ./generate.bat
3. Notice neuroph.dll has been created

# How To Use Bindings In Your Projects
1. Create a new console application in Xamarin Studio
2. Add A Reference to the 'neuroph.dll' file
3. Install the IKVM NuGet Package
	- **NOTE** install version 7.2.4630.5 of the Package because no other version will work!!!
4. Use Neuroph API's as usual

# How To Build The Test Project
1. Generate Neuroph Bindings As Per Above Instructions
2. Open The Test Project In Xamarin Studio
3. Restore NuGet Packages
4. Run Project As Usual

# Enjoy!
