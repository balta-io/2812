# Curso **2812 - Fundamentos do Azure, Git, Github e DevOps
Aprenda a versionar e publicar pacotes e aplicações no Azure de forma totalmente automatizada utilizando o GitHub como plataforma.

## Comandos do Azure
👉 [Blog](https://balta.io/blog/azure-github-actions)

## Outros comandos

#### Criar as Credenciais de publicação no Azure
```
az ad sp create-for-rbac --name "2812demo" --role contributor --scopes /subscriptions/<<SUBSCRIPTION>>/resourceGroups/blog --sdk-auth
```

#### Lista os servidores SQL
```
az sql server list --resource-group blog -o table
```

#### Lista os IPs permitidos no SQL Server
```
az sql server firewall-rule list --server blogbalta2012sqlserver --resource-group blog -o table
```

#### Adiciona um IP no SQL Server
```
az sql server firewall-rule create --resource-group blog --server blogbalta2012sqlserver --name ghactions --start-ip-address 1.2.3.4 --end-ip-address 5.6.7.8
```
