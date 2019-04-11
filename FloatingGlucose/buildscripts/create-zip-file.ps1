# Out-Zip.msh 
# creates out-Zip function 
# /\/\o\/\/ 2006    
# http://mow001.blogspot.com 

function out-zip($zipfilename, $files) { 
      #Load some assemblys. (No line break!)
    [System.Reflection.Assembly]::Load("WindowsBase,
       Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35") | Out-Null

    #Create a zip file named "MyZipFile.zip". (No line break!)
    $ZipPackage=[System.IO.Packaging.ZipPackage]::Open("$zipfilename",
       [System.IO.FileMode]"OpenOrCreate", [System.IO.FileAccess]"ReadWrite")

    #For each file you want to add, we must extract the bytes
    #and add them to a part of the zip file.
    ForEach ($file In $files)
    {
       $partName=New-Object System.Uri(( "/"+ $file.Name) , [System.UriKind]"Relative")
       #Create each part. (No line break!)
       $part=$ZipPackage.CreatePart($partName, "application/zip",
          [System.IO.Packaging.CompressionOption]"Maximum")
       $bytes=[System.IO.File]::ReadAllBytes($file)
       $stream=$part.GetStream()
       $stream.Write($bytes, 0, $bytes.Length)
       $stream.Close()
    }

    #Close the package when we're done.
    $ZipPackage.Close()
} 

function getGitTagOrReleaseName() {   
    $log = (git log --pretty=oneline --decorate | select -first 1)
    #$log = (git log --pretty=oneline --decorate | select -Index 3)
    $commit_id = "commit-" + ($log.Split(" ") | select -first 1).substring(0,8)

    $changes = (git status -s --porcelain)
    $has_uncommitted_changes = ($changes.length -ne 0)

    #echo "has changes?"$has_uncommitted_changes
    #echo "last id:"$commit_id

    if($log -match "tag: (?<ver>.*?)[,)]") {
        #basically, if there is a release associated with this commit, use that release isntead of commit
        $commit_id = $Matches["ver"]
    }

    if($has_uncommitted_changes) {
        $version =  $commit_id+"+changes"

    } else {
        $version = $commit_id

    }
    return $version
}



function getGitReleaseZipFileName() {
    #$projectname = "FloatingGlucose"
    $projectname = $env:projectname
	$buildconfigname = ($env:buildconfigname).toLower()
    $version = getGitTagOrReleaseName
    return "standalone-$projectname-$version-$buildconfigname.zip"
 
}

function writeVersionFile(){
    $buildver = getGitTagOrReleaseName
    #echo  $buildver  > version.txt #|out-file "version.txt" -Encoding "ascii"
    #writealltext must be used to avoid newline
    [System.IO.File]::WriteAllText("version.txt", $buildver)
    echo "wrote $buildver to version.txt"
}

function createReleaseZipFile(){
    
	$zipfilename = getGitReleaseZipFileName
	$dir = pwd
	$outpath = "$dir\$zipfilename"

	$files = ls . |  where { -not ($_.name.EndsWith(".vshost.exe") -or $_.name.EndsWith(".zip"))  }

    echo "writing zip to $outpath"
	$files | out-zip -zipfilename $outpath -files $files
	return $zipfilename
}

