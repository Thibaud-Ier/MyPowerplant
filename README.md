# MyPowerplant

1. Compiler l'application
Naviguez vers le répertoire de votre projet et utilisez la commande suivante pour compiler :
dotnet build

Cela générera les fichiers de votre application dans le répertoire bin/.

2. Lancer l'application sur le port 8888
Après avoir compilé, vous pouvez lancer l'application avec la commande suivante :
dotnet run --urls "http://localhost:8888"

Cette commande indique à votre API d'écouter sur le port 8888.

3. Vérifier l'application
Si tout s'est bien passé, vous pouvez accéder au swagger de l'API à l'adresse [localhost:8888/swagger/index.html.](http://localhost:8888/swagger/index.html)