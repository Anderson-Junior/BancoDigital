

\connect bancodigital

CREATE TABLE IF NOT EXISTS public."Conta"
(
    "ContaId" serial PRIMARY KEY,
    "NumeroConta" text COLLATE pg_catalog."default",
    "NumeroAgencia" text COLLATE pg_catalog."default",
    "TipoConta" text COLLATE pg_catalog."default",
    "Saldo" numeric NOT NULL,
    "CriadaEm" timestamp without time zone NOT NULL,
    "AtualizadaEm" timestamp without time zone NOT NULL DEFAULT '0001-01-01 00:00:00'::timestamp without time zone,
    CONSTRAINT "PK_Conta" PRIMARY KEY ("ContaId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Conta"
    OWNER to postgres;

INSERT INTO public."Conta"(
	"NumeroConta", "NumeroAgencia", "TipoConta", "Saldo", "CriadaEm", "AtualizadaEm")
	VALUES ('123456', '0004', 'corrente', '524', '2022-09-12 23:13:24', '2022-09-12 23:13:24');