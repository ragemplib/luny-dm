DROP DATABASE IF EXISTS luny;
CREATE DATABASE luny;
grant all privileges on database luny to postgres;
\c luny

CREATE TABLE player (
	id serial PRIMARY KEY,
	login VARCHAR(20) UNIQUE NOT NULL,
	email VARCHAR(20) UNIQUE NOT NULL,
	root_level INT DEFAULT 0,
	password VARCHAR(255) NOT NULL
);

CREATE TABLE stat (
	id serial PRIMARY KEY,
	player_id Int references player (id) NOT NULL,
	current_mode INT DEFAULT 0,
	current_room INT DEFAULT 0,
	last_connection_time timestamp,
	create_time timestamp
);

create table mode (
	id serial PRIMARY KEY,
	player_id Int references player (id) NOT NULL,
	kill INT DEFAULT 0,
	death INT DEFAULT 0,
	money INT DEFAULT 0,
	point INT DEFAULT 0,
	type INT DEFAULT 0,
	last_connected_time timestamp,
	last_exit_time timestamp
);

CREATE TABLE property (
	id serial PRIMARY KEY,
	name VARCHAR(20),
	cost INT,
	type INT,
	class INT
);

CREATE TABLE player_car (
	player_id Int PRIMARY KEY references player (id) NOT NULL,
	car_id Int references property (id) NOT NULL,
	destroyed Boolean,
	create_time timestamp
);

CREATE TABLE player_house (
	player_id Int PRIMARY KEY references player (id) NOT NULL,
	house_id Int references property (id) NOT NULL,
	create_time timestamp
);

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