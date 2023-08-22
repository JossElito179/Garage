 CREATE DATABASE garage;

 \c garage;

 CREATE TABLE users (
  idusers SERIAL PRIMARY KEY,
  nom VARCHAR(35),
  email VARCHAR(35),
  mdp VARCHAR(35)
 );

 CREATE TABLE employes (
    idemployes SERIAL PRIMARY KEY,
    nom VARCHAR(35),
    adresse VARCHAR(35),
    numero VARCHAR(35),
    posteActuel VARCHAR(35),
    salaireTJM REAL,
    CV VARCHAR(100)
 );

 CREATE TABLE experience (
    idexperience SERIAL PRIMARY KEY,
    idemployes INT NOT NULL,
    postePrecedent VARCHAR(35),
    duree INTEGER NOT NULL,
    societe VARCHAR(50),
    FOREIGN KEY (idemployes) REFERENCES employes(idemployes)
 );

CREATE TABLE diplome (
    iddiplome SERIAL PRIMARY KEY,
    idemployes INT NOT NULL,
    diplome VARCHAR(35),
    FOREIGN KEY (idemployes) REFERENCES employes(idemployes)
 );

CREATE TABLE voiture (
    idvoiture SERIAL PRIMARY KEY,
    typevoiture VARCHAR(50),
);

CREATE TABLE services (
   idservices SERIAL PRIMARY KEY,   
   types VARCHAR(50),
);

CREATE TABLE voiture_services (
    idvoiture_services SERIAL PRIMARY KEY,
    idvoiture INT NOT NULL,
    idservices INT NOT NULL,
    prix DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (idservices) REFERENCES services(idservices),
    FOREIGN KEY (idvoiture) REFERENCES voiture(idvoiture)
);