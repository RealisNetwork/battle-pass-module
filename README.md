Installation You can also install via git url by adding these entries in your manifest.json

"com.namespace.packagename": "https://@github.com/user/repo.git#upm" Update UPM branch guide Push you all changes to develop branch Checkout to develop branch Invoke in terminal git subtree split --prefix=Assets/Package --annotate="[upm] " --rejoin -b upm Push changes to upm branch git push origin upm
