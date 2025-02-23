del bin\SBRunScr.tests.html
dotnet clean
dotnet test test --logger html --verbosity detailed --results-directory "bin"
cd bin
del SBRunScr.pdb
del SBRunScr.deps.json
rmdir test /S /Q
rename TestResult*.html SBRunScr.tests.html
tar -c -f ..\release\SBRunScr.zip --exclude *.html *
cd ..
