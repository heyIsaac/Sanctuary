================================================================================
KILL ZOMBIES - Projeto Unity (XR / First Person)
================================================================================

## DESCRIÇÃO

KillZombies é um projeto Unity que combina controle em primeira pessoa,
interação com ambiente (portas), combate a zumbis e áudio. O projeto está
configurado para uso com Meta XR (Oculus) .

## REQUISITOS

- Unity 6
- Pacotes: Input System, XR Plugin Management, Meta XR Core SDK (Oculus)
- Para build Meta Quest: Oculus/Meta XR SDK configurado e dispositivo

## COMO ABRIR O PROJETO

1. Abra o Unity Hub.
2. Add → selecione a pasta do projeto (onde está este README).
3. Abra o projeto com a versão do Unity indicada.
4. Aguarde a importação dos assets e a compilação.

## CENA PRINCIPAL E BUILD

- Cena principal: Assets/Scenes/SampleScene.unity
- Build Settings: File → Build Settings. A cena SampleScene já deve estar em
  "Scenes In Build" (index 0). Para Quest/Android, altere a plataforma para
  Android e configure Player Settings (XR Plug-in Management, etc.).

## COMO JOGAR (NO EDITOR)

1. Abra Assets/Scenes/SampleScene.unity.
2. Pressione Play.
3. Use o teclado e mouse (ou controles configurados no Input System) para
   mover, mirar, atirar e interagir com portas.
4. Elimine os zumbis e explore o ambiente.

## ESTRUTURA DO PROJETO (PASTAS PRINCIPAIS)

- Assets/
  - Scenes/ Cenas do jogo (SampleScene = cena principal)
  - Scripts/ Scripts do jogo (jogador, zumbi, arma, porta, interação)
  - Prefabs/ Prefabs do projeto (zumbi, animator)
  - Sounds/ Áudio (trilha, efeitos como tiro)
  - Settings/ URP e configurações de renderização
  - StarterAssets/ Assets do template (ambiente, FPC, input)
  - Polytope Studio/ Ambiente lowpoly (árvores, cenário, vila)
  - Supercyan Character Pack Zombie Sample/ Zumbis e animações
  - LP_SciFiWeapons_Lite/ Armas
- ProjectSettings/ Configurações do projeto (Input, Build, etc.)
- Packages/ Pacotes UPM (manifest.json, etc.)

## NOMENCLATURA

- Scripts: PascalCase (ex.: ArmaJogador.cs, ZumbiVida.cs).
- Prefabs: minúsculo com sufixo quando útil (ex.: zombie.prefab).
- Cenas: PascalCase (ex.: SampleScene.unity).
- Pastas: PascalCase ou descritivas (Scenes, Scripts, Sounds).

## REFLEXÃO / APRENDIZADO

================================================================================
Para entrega: inclua o link do repositório GitHub no arquivo REPOSITORIO.txt
================================================================================
