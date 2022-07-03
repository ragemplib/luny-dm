DROP DATABASE IF EXISTS luny;
CREATE DATABASE luny;
grant all privileges on database luny to postgres;
\c luny
---------------------------------------------------------------------------------------------------------------------------
-- PLAYER

CREATE TABLE player (
	id serial PRIMARY KEY,
	login VARCHAR(20) UNIQUE NOT NULL,
	email VARCHAR(20) UNIQUE NOT NULL,
	root_level INT DEFAULT 0,
	password VARCHAR(255) NOT NULL
);

create table mode (
	id serial PRIMARY KEY,
	player_id Int references player (id) NOT NULL,
	kill INT DEFAULT 0,
	death INT DEFAULT 0,
	money INT DEFAULT 0,
	point INT DEFAULT 0,
	type INT DEFAULT 0,
	create_time timestamp
);

create table abilities (
	id serial PRIMARY KEY,
	player_id Int references player (id) NOT NULL,
	fast_respawn bool default false,
	ghetto_veh bool default false,
	immortal_car bool default false,
	better_gun_ghetto bool default false,
	room_creation bool default false,
	gang_creation bool default false
);

---------------------------------------------------------------------------------------------------------------------------
-- GANG

CREATE TABLE gang (
	id serial PRIMARY KEY,
	owner_player_id Int references player (id) NOT NULL
);

---------------------------------------------------------------------------------------------------------------------------
-- PROPERTY OWNERSHIP 

CREATE TABLE ownership (
	id serial PRIMARY KEY,
	owner_id Int,
	type Int
);

CREATE TABLE transport (
	id serial PRIMARY KEY,
	name VARCHAR(20),
	cost INT,
	type INT,
	class INT
);

CREATE TABLE house (
	id serial PRIMARY KEY,
	name VARCHAR(20),
	cost INT,
	type INT,
	class INT
);

CREATE TABLE owned_transport (
	player_id Int PRIMARY KEY references player (id) NOT NULL,
	car_id Int references transport (id) NOT NULL,
	destroyed Boolean
);

CREATE TABLE owned_house (
	player_id Int PRIMARY KEY references player (id) NOT NULL,
	house_id Int references house (id) NOT NULL
);

CREATE TABLE owned_house_storage (
	owned_house_id Int references house (id) NOT NULL,
	item_id Int,
	amount Int
);

---------------------------------------------------------------------------------------------------------------------------
-- TRANSACTIONS

CREATE TABLE account_type (
	id serial PRIMARY KEY
);

CREATE TABLE balance_account (
	id serial PRIMARY KEY,
	type INT references account_type (id) NOT NULL,
	player_id Int references player (id) NOT NULL
);

CREATE TABLE transaction (
	id serial PRIMARY KEY,
	account_type INT references balance_account (id) NOT NULL,
	balance INT DEFAULT 0,
	hold INT DEFAULT 0,
	amount INT DEFAULT 0
)

---------------------------------------------------------------------------------------------------------------------------