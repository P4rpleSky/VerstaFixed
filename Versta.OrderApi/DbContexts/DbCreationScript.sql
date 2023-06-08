DROP TABLE IF EXISTS addresses CASCADE;
CREATE TABLE addresses
(
    id serial PRIMARY KEY,
    city varchar(32) NOT NULL,
	street_name varchar(64) NOT NULL,
	house_number int NOT NULL,
	block varchar(8),
	building_number int,
	flat_number int
);

INSERT INTO addresses(city, street_name, house_number, block, building_number, flat_number)
VALUES
('Москва', 'улица Есенина', 20, '3А', NULL, 20),
('Новосибирск', 'переулок Ашхабадский', 40, NULL, NULL, NULL),
('Санкт-Петербург', 'проспект Науки', 100, '9Б', 2, 100),
('Ростов-на-Дону', 'улица Таганрогская', 50, NULL, 1, 70);

DROP TABLE IF EXISTS orders CASCADE;
CREATE TABLE orders
(
    id serial PRIMARY KEY,
    sender_address_id int NOT NULL,
	recipient_address_id int NOT NULL,
	cargo_weight NUMERIC(6,3) NOT NULL,
    pickup_date timestamp NOT NULL,
	
	CONSTRAINT FK_sender_address_id FOREIGN KEY (sender_address_id) REFERENCES addresses(id),
	CONSTRAINT FK_recipient_address_id FOREIGN KEY (recipient_address_id) REFERENCES addresses(id)
);


INSERT INTO orders(sender_address_id, recipient_address_id, cargo_weight, pickup_date)
VALUES
(1, 2, 23.3, CURRENT_TIMESTAMP),
(4, 2, 100.677, CURRENT_TIMESTAMP),
(3, 4, 23.3, CURRENT_TIMESTAMP);

SELECT * FROM orders
LEFT JOIN addresses AS a1 ON a1.id = orders.sender_address_id 
LEFT JOIN addresses AS a2 ON a2.id = orders.recipient_address_id