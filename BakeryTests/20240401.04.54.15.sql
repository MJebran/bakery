-- new one
-- PostgreSQL database dump
create role "azure_pg_admin";
create role "bakeryadmin";
--

-- Dumped from database version 16.0
-- Dumped by pg_dump version 16.2 (Debian 16.2-1.pgdg120+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: bakery; Type: SCHEMA; Schema: -; Owner: azure_pg_admin
--

CREATE SCHEMA bakery;


ALTER SCHEMA bakery OWNER TO azure_pg_admin;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: category; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.category (
    category_id integer NOT NULL,
    category_name text,
    category_description text
);


ALTER TABLE bakery.category OWNER TO bakeryadmin;

--
-- Name: category_category_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.category ALTER COLUMN category_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.category_category_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: customitem; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.customitem (
    custom_item_id integer NOT NULL,
    item_id integer NOT NULL
);


ALTER TABLE bakery.customitem OWNER TO bakeryadmin;

--
-- Name: customitem_custom_item_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.customitem ALTER COLUMN custom_item_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.customitem_custom_item_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: customitemtopping; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.customitemtopping (
    custom_item_topping_id integer NOT NULL,
    custom_item_topping_quantity integer,
    custom_item_id integer NOT NULL,
    topping_id integer NOT NULL
);


ALTER TABLE bakery.customitemtopping OWNER TO bakeryadmin;

--
-- Name: customitemtopping_custom_item_topping_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.customitemtopping ALTER COLUMN custom_item_topping_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.customitemtopping_custom_item_topping_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: favoriteitem; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.favoriteitem (
    favoriteitem_id integer NOT NULL,
    user_id integer NOT NULL,
    item_id integer NOT NULL
);


ALTER TABLE bakery.favoriteitem OWNER TO bakeryadmin;

--
-- Name: favoriteitem_favoriteitem_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.favoriteitem ALTER COLUMN favoriteitem_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.favoriteitem_favoriteitem_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: itempurchase; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.itempurchase (
    itempurchase_id integer NOT NULL,
    itempurchase_quantity integer,
    itempurchase_item_id integer NOT NULL,
    purchase_id integer NOT NULL
);


ALTER TABLE bakery.itempurchase OWNER TO bakeryadmin;

--
-- Name: itempurchase_itempurchase_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.itempurchase ALTER COLUMN itempurchase_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.itempurchase_itempurchase_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: itemtype; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.itemtype (
    item_type_id integer NOT NULL,
    item_name text,
    item_price numeric,
    itme_calories integer,
    item_weight numeric,
    item_description text,
    category_id integer NOT NULL,
    size_id integer NOT NULL
);


ALTER TABLE bakery.itemtype OWNER TO bakeryadmin;

--
-- Name: itemtype_item_type_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.itemtype ALTER COLUMN item_type_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.itemtype_item_type_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: purchase; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.purchase (
    purchase_id integer NOT NULL,
    purcahse_date date,
    ispayed boolean NOT NULL,
    purchase_user_id integer NOT NULL
);


ALTER TABLE bakery.purchase OWNER TO bakeryadmin;

--
-- Name: purchase_purchase_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.purchase ALTER COLUMN purchase_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.purchase_purchase_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: role; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.role (
    role_id integer NOT NULL,
    role_name text,
    role_description text
);


ALTER TABLE bakery.role OWNER TO bakeryadmin;

--
-- Name: role_role_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.role ALTER COLUMN role_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.role_role_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: size; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.size (
    size_id integer NOT NULL,
    size_name character varying(15)
);


ALTER TABLE bakery.size OWNER TO bakeryadmin;

--
-- Name: size_size_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.size ALTER COLUMN size_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.size_size_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: topping; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery.topping (
    topping_id integer NOT NULL,
    topping_name text,
    topping_price numeric,
    topping_weight numeric,
    topping_calories integer,
    topping_unit text
);


ALTER TABLE bakery.topping OWNER TO bakeryadmin;

--
-- Name: topping_topping_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery.topping ALTER COLUMN topping_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.topping_topping_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: user; Type: TABLE; Schema: bakery; Owner: bakeryadmin
--

CREATE TABLE bakery."user" (
    user_id integer NOT NULL,
    user_name text,
    user_email text,
    user_phone integer,
    user_role_id integer NOT NULL
);


ALTER TABLE bakery."user" OWNER TO bakeryadmin;

--
-- Name: user_user_id_seq; Type: SEQUENCE; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE bakery."user" ALTER COLUMN user_id ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME bakery.user_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Data for Name: category; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.category (category_id, category_name, category_description) FROM stdin;
1	Cake	this is a cake
3	Cupcake	this is a cup cake
2	Cookie	this is a cookie
\.


--
-- Data for Name: customitem; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.customitem (custom_item_id, item_id) FROM stdin;
56	10
33	10
34	11
36	10
38	10
44	10
48	10
\.


--
-- Data for Name: customitemtopping; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.customitemtopping (custom_item_topping_id, custom_item_topping_quantity, custom_item_id, topping_id) FROM stdin;
32	1	33	1
33	3	34	1
35	1	36	1
37	1	38	1
43	1	44	1
47	7	48	1
54	2	56	1
\.


--
-- Data for Name: favoriteitem; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.favoriteitem (favoriteitem_id, user_id, item_id) FROM stdin;
\.


--
-- Data for Name: itempurchase; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.itempurchase (itempurchase_id, itempurchase_quantity, itempurchase_item_id, purchase_id) FROM stdin;
54	1	56	9
42	1	44	1
46	1	48	1
\.


--
-- Data for Name: itemtype; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.itemtype (item_type_id, item_name, item_price, itme_calories, item_weight, item_description, category_id, size_id) FROM stdin;
10	Chocolate Cake	4.99	500	300	Chocolate cake is a cake that uses Chocolate as a primary ingredient. Strawberries may be used in the cake batter, atop cakes and in a chocolate cake’s frosting.	1	1
11	Special Wedding Cake	100	200	20	Special Wedding Cake	1	1
28	Chocolate Chip Cookie	1.00	200	10	Chocolate chip cookies are made with semisweet chocolate chips and are vegetarian. They are thick and chewy, soft on the inside, and crunchy on the outside	2	0
\.


--
-- Data for Name: purchase; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.purchase (purchase_id, purcahse_date, ispayed, purchase_user_id) FROM stdin;
1	\N	f	1
7	\N	f	7
8	\N	f	10
9	\N	f	8
\.


--
-- Data for Name: role; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.role (role_id, role_name, role_description) FROM stdin;
2	user	this is a customer with no admin privileges
1	admin	this is an admin with privileges
\.


--
-- Data for Name: size; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.size (size_id, size_name) FROM stdin;
0	Small
1	Medium
2	Big
\.


--
-- Data for Name: topping; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery.topping (topping_id, topping_name, topping_price, topping_weight, topping_calories, topping_unit) FROM stdin;
1	Strawberry	1.25	150	50	cup
\.


--
-- Data for Name: user; Type: TABLE DATA; Schema: bakery; Owner: bakeryadmin
--

COPY bakery."user" (user_id, user_name, user_email, user_phone, user_role_id) FROM stdin;
1	Carlos Felipe Blanco Castro	blancocastrocarlosfelipe@gmail.com	\N	1
7	Mustafa Jebran	jebran.mustafa@gmail.com	\N	1
8	Luris Solis	solisluris@gmail.com	\N	1
10	Carlos Unknown	kakeybakery@gmail.com	\N	1
\.


--
-- Name: category_category_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.category_category_id_seq', 1, false);


--
-- Name: customitem_custom_item_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.customitem_custom_item_id_seq', 56, true);


--
-- Name: customitemtopping_custom_item_topping_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.customitemtopping_custom_item_topping_id_seq', 54, true);


--
-- Name: favoriteitem_favoriteitem_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.favoriteitem_favoriteitem_id_seq', 1, false);


--
-- Name: itempurchase_itempurchase_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.itempurchase_itempurchase_id_seq', 54, true);


--
-- Name: itemtype_item_type_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.itemtype_item_type_id_seq', 28, true);


--
-- Name: purchase_purchase_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.purchase_purchase_id_seq', 9, true);


--
-- Name: role_role_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.role_role_id_seq', 1, false);


--
-- Name: size_size_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.size_size_id_seq', 1, false);


--
-- Name: topping_topping_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.topping_topping_id_seq', 1, true);


--
-- Name: user_user_id_seq; Type: SEQUENCE SET; Schema: bakery; Owner: bakeryadmin
--

SELECT pg_catalog.setval('bakery.user_user_id_seq', 14, true);


--
-- Name: category category_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.category
    ADD CONSTRAINT category_pkey PRIMARY KEY (category_id);


--
-- Name: customitem customitem_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.customitem
    ADD CONSTRAINT customitem_pkey PRIMARY KEY (custom_item_id);


--
-- Name: customitemtopping customitemtopping_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.customitemtopping
    ADD CONSTRAINT customitemtopping_pkey PRIMARY KEY (custom_item_topping_id);


--
-- Name: favoriteitem favoriteitem_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.favoriteitem
    ADD CONSTRAINT favoriteitem_pkey PRIMARY KEY (favoriteitem_id);


--
-- Name: itempurchase itempurchase_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itempurchase
    ADD CONSTRAINT itempurchase_pkey PRIMARY KEY (itempurchase_id);


--
-- Name: itemtype itemtype_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itemtype
    ADD CONSTRAINT itemtype_pkey PRIMARY KEY (item_type_id);


--
-- Name: purchase purchase_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.purchase
    ADD CONSTRAINT purchase_pkey PRIMARY KEY (purchase_id);


--
-- Name: role role_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (role_id);


--
-- Name: size size_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.size
    ADD CONSTRAINT size_pkey PRIMARY KEY (size_id);


--
-- Name: topping topping_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.topping
    ADD CONSTRAINT topping_pkey PRIMARY KEY (topping_id);


--
-- Name: user user_pkey; Type: CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (user_id);


--
-- Name: customitem customitem_item_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.customitem
    ADD CONSTRAINT customitem_item_id_fkey FOREIGN KEY (item_id) REFERENCES bakery.itemtype(item_type_id);


--
-- Name: customitemtopping customitemtopping_custom_item_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.customitemtopping
    ADD CONSTRAINT customitemtopping_custom_item_id_fkey FOREIGN KEY (custom_item_id) REFERENCES bakery.customitem(custom_item_id);


--
-- Name: customitemtopping customitemtopping_topping_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.customitemtopping
    ADD CONSTRAINT customitemtopping_topping_id_fkey FOREIGN KEY (topping_id) REFERENCES bakery.topping(topping_id);


--
-- Name: favoriteitem favoriteitem_item_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.favoriteitem
    ADD CONSTRAINT favoriteitem_item_id_fkey FOREIGN KEY (item_id) REFERENCES bakery.itemtype(item_type_id);


--
-- Name: favoriteitem favoriteitem_user_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.favoriteitem
    ADD CONSTRAINT favoriteitem_user_id_fkey FOREIGN KEY (user_id) REFERENCES bakery."user"(user_id);


--
-- Name: itempurchase itempurchase_itempurchase_item_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itempurchase
    ADD CONSTRAINT itempurchase_itempurchase_item_id_fkey FOREIGN KEY (itempurchase_item_id) REFERENCES bakery.customitem(custom_item_id);


--
-- Name: itempurchase itempurchase_purchase_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itempurchase
    ADD CONSTRAINT itempurchase_purchase_id_fkey FOREIGN KEY (purchase_id) REFERENCES bakery.purchase(purchase_id);


--
-- Name: itemtype itemtype_category_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itemtype
    ADD CONSTRAINT itemtype_category_id_fkey FOREIGN KEY (category_id) REFERENCES bakery.category(category_id);


--
-- Name: itemtype itemtype_size_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.itemtype
    ADD CONSTRAINT itemtype_size_id_fkey FOREIGN KEY (size_id) REFERENCES bakery.size(size_id);


--
-- Name: purchase purchase_purchase_user_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery.purchase
    ADD CONSTRAINT purchase_purchase_user_id_fkey FOREIGN KEY (purchase_user_id) REFERENCES bakery."user"(user_id);


--
-- Name: user user_user_role_id_fkey; Type: FK CONSTRAINT; Schema: bakery; Owner: bakeryadmin
--

ALTER TABLE ONLY bakery."user"
    ADD CONSTRAINT user_user_role_id_fkey FOREIGN KEY (user_role_id) REFERENCES bakery.role(role_id);


--
-- PostgreSQL database dump complete
--

