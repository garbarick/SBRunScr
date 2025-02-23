del release\SBRunScr.tests.html
dotnet clean
dotnet test test --logger html --verbosity detailed --results-directory "release"
cd release
del SBRunScr.pdb
del SBRunScr.deps.json
rmdir test /S /Q
rename TestResult*.html SBRunScr.tests.html
tar -c -f SBRunScr.zip --exclude SBRunScr.zip --exclude *.html *
cd ..
