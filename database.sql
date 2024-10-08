PGDMP      ;                |            cadastro_funcionarios_cervantes    16.4    16.4     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16398    cadastro_funcionarios_cervantes    DATABASE     �   CREATE DATABASE cadastro_funcionarios_cervantes WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
 /   DROP DATABASE cadastro_funcionarios_cervantes;
                postgres    false            �            1259    16400    funcionario    TABLE     �   CREATE TABLE public.funcionario (
    id integer NOT NULL,
    nome character varying NOT NULL,
    telefone bigint NOT NULL,
    CONSTRAINT telefone CHECK ((telefone >= 1))
);
    DROP TABLE public.funcionario;
       public         heap    postgres    false            �            1259    16399    funcionario_id_seq    SEQUENCE     �   CREATE SEQUENCE public.funcionario_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.funcionario_id_seq;
       public          postgres    false    216            �           0    0    funcionario_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.funcionario_id_seq OWNED BY public.funcionario.id;
          public          postgres    false    215            �            1259    24577    operacao_log    TABLE     �   CREATE TABLE public.operacao_log (
    id integer NOT NULL,
    data_hora timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    tipo_operacao character varying(10)
);
     DROP TABLE public.operacao_log;
       public         heap    postgres    false            �            1259    24576    operacao_log_id_seq    SEQUENCE     �   CREATE SEQUENCE public.operacao_log_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.operacao_log_id_seq;
       public          postgres    false    218            �           0    0    operacao_log_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.operacao_log_id_seq OWNED BY public.operacao_log.id;
          public          postgres    false    217            U           2604    16403    funcionario id    DEFAULT     p   ALTER TABLE ONLY public.funcionario ALTER COLUMN id SET DEFAULT nextval('public.funcionario_id_seq'::regclass);
 =   ALTER TABLE public.funcionario ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    215    216            V           2604    24580    operacao_log id    DEFAULT     r   ALTER TABLE ONLY public.operacao_log ALTER COLUMN id SET DEFAULT nextval('public.operacao_log_id_seq'::regclass);
 >   ALTER TABLE public.operacao_log ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    218    217    218            �          0    16400    funcionario 
   TABLE DATA           9   COPY public.funcionario (id, nome, telefone) FROM stdin;
    public          postgres    false    216   {       �          0    24577    operacao_log 
   TABLE DATA           D   COPY public.operacao_log (id, data_hora, tipo_operacao) FROM stdin;
    public          postgres    false    218   �       �           0    0    funcionario_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.funcionario_id_seq', 98, true);
          public          postgres    false    215            �           0    0    operacao_log_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.operacao_log_id_seq', 137, true);
          public          postgres    false    217            Z           2606    16405    funcionario funcionario_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.funcionario
    ADD CONSTRAINT funcionario_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.funcionario DROP CONSTRAINT funcionario_pkey;
       public            postgres    false    216            \           2606    24629 $   funcionario funcionario_telefone_key 
   CONSTRAINT     c   ALTER TABLE ONLY public.funcionario
    ADD CONSTRAINT funcionario_telefone_key UNIQUE (telefone);
 N   ALTER TABLE ONLY public.funcionario DROP CONSTRAINT funcionario_telefone_key;
       public            postgres    false    216            ^           2606    24583    operacao_log operacao_log_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.operacao_log
    ADD CONSTRAINT operacao_log_pkey PRIMARY KEY (id);
 H   ALTER TABLE ONLY public.operacao_log DROP CONSTRAINT operacao_log_pkey;
       public            postgres    false    218            �      x������ � �      �      x������ � �     