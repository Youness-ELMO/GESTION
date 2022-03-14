create database GESTION
use GESTION

create table Produit (IdProduit int primary key,
						nomProduit varchar(20),
						prixProduit float)


create table Client(IdClient int primary key,
					nomClient varchar(20),
					villeClient varchar(30))


create table Commande(IdCommmande int primary key ,
						dateCommande date,
						IdClient int foreign key references Client(IdClient) )


create table Detail (IdCommmande int foreign key references Commande (IdCommmande),
					IdProduit int foreign key references Produit(IdProduit) ,
					quantite int )


insert into Produit values(1,'OPPO',3500.5),(2,'Samsung S10',8490),(3,'ULTRA HD ',5411),(4,'Bracelet Or',5000)

insert into Client values(1,'anass korchi','casa'),(2,'fathi fouli','fes'),(3,'zakaria ghanam','rabat'),(4,'marouane folou','casa')

insert into Commande values(1,'12/09/2021',4),(2,'02/05/2016',3),(3,'12/12/2011',2),(4,'01/11/2019',1),(5,'01/11/2019',1)

insert into Detail values(1,4,100),(2,3,320),(3,2,452),(4,1,910)

select*from Produit
select*from Client
select*from Commande
select*from Detail