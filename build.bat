del bin\SBRunScr.tests.html
dotnet clean
dotnet test test --logger html --verbosity detailed --results-directory "bin"
cd bin
del SBRunScr.pdb
rmdir test /S /Q
cd runtimes
rmdir browser-wasm /S /Q
rmdir linux-arm /S /Q
rmdir linux-arm64 /S /Q
rmdir linux-armel /S /Q
rmdir linux-mips64 /S /Q
rmdir linux-musl-arm /S /Q
rmdir linux-musl-arm64 /S /Q
rmdir linux-musl-s390x /S /Q
rmdir linux-musl-x64 /S /Q
rmdir linux-ppc64le /S /Q
rmdir linux-s390x /S /Q
rmdir linux-x64 /S /Q
rmdir linux-x86 /S /Q
rmdir maccatalyst-arm64 /S /Q
rmdir maccatalyst-x64 /S /Q
rmdir osx-arm64 /S /Q
rmdir osx-x64 /S /Q
rmdir win-arm /S /Q
rmdir win-arm64 /S /Q
rmdir win-x86 /S /Q
cd ..
rename TestResult*.html SBRunScr.tests.html
tar -c -f ..\release\SBRunScr.zip --exclude *.html *
cd ..
