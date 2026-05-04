CREATE TABLE users
(
    id INT identity(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(100) NOT NULL,
    user_type NVARCHAR(50) NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_users PRIMARY KEY (id),
    CONSTRAINT uq_users_username UNIQUE (username),
    CONSTRAINT chk_user_type CHECK (user_type IN ('r', 'm', 'a'))
);



CREATE TABLE specialties
(
    id INT identity(1,1),
    specialty_name NVARCHAR(100) NOT NULL,

    CONSTRAINT pk_Specialty PRIMARY KEY (id),
    CONSTRAINT uq_specialty_name UNIQUE (specialty_name)
);



CREATE TABLE members
(
    id INT identity(1,1),
    full_name NVARCHAR(100) NOT NULL,
    phone_pumber NVARCHAR(20) NULL,
    birth_date DATE NULL,
    start_date DATE NOT NULL,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),
    end_date DATE NULL,

    CONSTRAINT pk_members PRIMARY KEY (id),

    CONSTRAINT fk_members_users
        FOREIGN KEY (created_by)
        REFERENCES users(id),

    CONSTRAINT chk_member_phone
        CHECK (LEN(phone_pumber) > 10),

    CONSTRAINT chk_member_age
        CHECK (DATEDIFF(YEAR, birth_date, GETDATE()) > 18)
);

CREATE INDEX ix_full_name
ON members(full_name);




CREATE TABLE trainers
(
    id INT identity(1,1),
    full_name NVARCHAR(100) NOT NULL,
    phone_pumber NVARCHAR(20) NOT NULL,
    address NVARCHAR(1000) NULL,
    birth_date DATE NULL,
    specialty_id INT,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_trainers PRIMARY KEY (id),

    CONSTRAINT fk_trainers_users
        FOREIGN KEY (created_by)
        REFERENCES users(id),

    CONSTRAINT fk_trainers_speciality
        FOREIGN KEY (specialty_id)
        REFERENCES specialties(id),

    CONSTRAINT chk_trainer_phone
        CHECK (LEN(phone_pumber) > 10),

    CONSTRAINT chk_trainer_age
        CHECK (DATEDIFF(YEAR, birth_date, GETDATE()) > 18)
);

CREATE INDEX ix_full_name
ON trainers(full_name);




CREATE TABLE rooms
(
    id INT identity(1,1),
    room_name NVARCHAR(100) NOT NULL,
    capacity INT NOT NULL,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_rooms PRIMARY KEY (id),

    CONSTRAINT fk_rooms_users
        FOREIGN KEY (created_by)
        REFERENCES users(id),

    CONSTRAINT chk_room_capacity
        CHECK (capacity > 0)
);




CREATE TABLE classes
(
    id INT identity(1,1),
    classe_name NVARCHAR(100) NOT NULL,
    trainer_id int,
    room_id INT,
    class_date DATETIME NOT NULL,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_classes PRIMARY KEY (id),

    CONSTRAINT fk_classes_trainers
        FOREIGN KEY (trainer_id)
        REFERENCES trainers(id),

    CONSTRAINT fk_classes_rooms
        FOREIGN KEY (room_id)
        REFERENCES rooms(id),

    CONSTRAINT fk_classes_users
        FOREIGN KEY (created_by)
        REFERENCES users(id)
);

CREATE INDEX ix_classdate
ON classes(class_date);




CREATE TABLE bookings
(
    id INT identity(1,1),
    booking_date DATETIME NOT NULL,
    member_id INT ,
    class_id INT ,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_bookings PRIMARY KEY (id),

    CONSTRAINT fk_bookings_members
        FOREIGN KEY (member_id)
        REFERENCES members(id),

    CONSTRAINT fk_bookings_classes
        FOREIGN KEY (class_id)
        REFERENCES classes(id),

    CONSTRAINT fk_bookings_users
        FOREIGN KEY (created_by)
        REFERENCES users(id)
);




CREATE TABLE payments
(
    id INT identity(1,1),
    payment_date DATETIME NOT NULL,
    member_id INT,
    amount DECIMAL(10,2) NOT NULL,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_payments PRIMARY KEY (id),

    CONSTRAINT fk_payments_members
        FOREIGN KEY (member_id)
        REFERENCES members(id),

    CONSTRAINT fk_payments_users
        FOREIGN KEY (created_by)
        REFERENCES users(id),

    CONSTRAINT chk_payments_amount
        CHECK (amount > 0)
);




CREATE TABLE subscriptions
(
    id INT identity(1,1),
    member_id INT,
    subscription_type NVARCHAR(50) NOT NULL,
    subscription_amount DECIMAL(10,2) NOT NULL,
    paid_amount DECIMAL(10,2) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    created_by INT NOT NULL,
    creation_date DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_subscriptions PRIMARY KEY (id),

    CONSTRAINT fk_subscriptions_members
        FOREIGN KEY (member_id)
        REFERENCES members(id),

    CONSTRAINT fk_subscriptions_users
        FOREIGN KEY (created_by)
        REFERENCES users(id),

    CONSTRAINT chk_subscriptions_amount
        CHECK (subscription_amount >= paid_amount),

    CONSTRAINT chk_subscriptions_date
        CHECK (end_date > start_date)
);