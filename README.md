🏦 Validador de Cartão de Crédito — Desafio DIO

Este projeto foi desenvolvido como parte de um desafio da DIO (Digital Innovation One), onde o objetivo era criar um sistema validador de cartões de crédito, utilizando lógica de negócio, boas práticas de programação e apoio do GitHub Copilot.

O programa identifica a bandeira do cartão e também valida a autenticidade do número utilizando o algoritmo de Luhn.

🚀 Funcionalidades
✔️ 1. Normalização do número do cartão

Remove qualquer caractere que não seja dígito (0–9).
Exemplo:
"4111 1111-1111 1111" se torna "4111111111111111".

✔️ 2. Identificação da bandeira

O sistema identifica automaticamente:

Visa

Mastercard

American Express

Discover

Diners

JCB

Elo

Hipercard

Desconhecida (caso não se encaixe em nenhum padrão)

A identificação é feita analisando:

Prefixos (BIN)

Quantidade de dígitos

Regras específicas de cada bandeira

✔️ 3. Validação pelo Algoritmo de Luhn

Algoritmo usado mundialmente para verificar a autenticidade de cartões:

Dobra dígitos alternados

Ajusta valores maiores que 9

Soma final deve ser múltiplo de 10

Retorna:

Válido

Inválido

✔️ 4. Entrada via Terminal ou Argumentos

O usuário pode:

Digitar manualmente o número do cartão

Ou passar valores via args ao executar o programa

Exemplo: