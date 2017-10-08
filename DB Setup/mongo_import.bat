@echo off

setlocal

mongo PublishersDb --eval "db.dropDatabase()"
mongoimport -d PublishersDb -c User User.json
mongoimport -d PublishersDb -c Book Book.json
mongoimport -d PublishersDb -c Role Role.json
mongoimport -d PublishersDb -c BookDemand BookDemand.json

:end