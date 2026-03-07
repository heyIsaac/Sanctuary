# 🧟‍♂️ VR KillZombies

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Meta Quest](https://img.shields.io/badge/Meta_Quest-045FEE?style=for-the-badge&logo=meta&logoColor=white)

## 📖 Sobre o Projeto

**KillZombies** é um protótipo de ambiente interativo em primeira pessoa desenvolvido na Unity, criado com foco em otimização e imersão para **Realidade Virtual (Meta Quest)**. O projeto foi construído para demonstrar conceitos práticos de Level Design, Inteligência Artificial (NavMesh), interação baseada em Raycast e integração de Áudio (SFX/BGM).

O ambiente transporta o jogador para um vale misterioso "Low Poly" infestado por inimigos, onde a exploração e a sobrevivência andam lado a lado.

## ✨ Funcionalidades Principais (Features)

- 🚪 **Interação das "portas":** Portas automáticas com feedback visual (cor de destaque) e sonoro, operadas por meio de disparos de Raycast.
- 🧟 **IA Inimiga (Pathfinding):** Zumbis programados com `NavMeshAgent` que perseguem o jogador de forma inteligente, desviando de obstáculos
- 🔫 **Sistema de Combate:** Mecânica de tiro (Hitscan) direto do centro da câmera, contendo:
  - Arma visual _Sci-Fi_ vinculada à visão do jogador.
  - Mira centralizada em Canvas UI.
  - Sistema de vida para o inimigo (3 tiros para ser eliminado).
  - Animações de dano, perseguição e morte interligadas via _Animator Controller_.
- 💬 **UX/UI Integrada:** Sistema de "Toast" (Aviso em tela temporário) utilizando _TextMeshPro_ para guiar o jogador na primeira interação já que não tive tempo para melhorar o cenário de nascimento.
- 🎧 **Design de Som (AudioSFX):** Trilha sonora ambiente contínua e efeitos sonoros espacializados ao realizar disparos.
- 🥽 **Arquitetura VR-Ready:** Projeto configurado tecnicamente para rodar no sistema Android, utilizando o **Meta XR Core SDK**.

---

## 🎮 Como Jogar e Testar (Modo PC)

Embora o projeto seja focado no Meta Quest, toda a movimentação inicial e interações foram adaptadas para serem avaliadas e testadas diretamente no PC.

### Controles

- `W, A, S, D` - Movimentação do Personagem
- `Mouse` - Movimentação da Câmera (Visão)
- `Botão Esquerdo do Mouse` - Atirar
- `E` - Interagir com o cenário (Mirar para a porta azul para abrir/fechar)

### Passo a Passo para rodar na Unity:

1. Faça o clone ou download deste repositório.
2. Abra o projeto através do **Unity Hub** (Recomendado usar a mesma versão na qual o projeto foi salvo).
3. Na aba `Project`, navegue até a pasta `Assets/Scenes` e abra a **SampleScene**.
4. Clique no botão **Play** (▶) no topo da tela do editor.
5. Siga as instruções do _Toast_ inicial na tela para interagir com a porta e prepare-se para atirar nos zumbis!

---

## ⚙️ Como Funciona (Arquitetura Técnica)

O projeto foi construído seguindo boas práticas de engenharia de software com C#, utilizando scripts modulares, escaláveis e fortemente documentados:

- **InteracaoJogador.cs:** Controla as interações passíficas do jogador. Dispara um raio invisível (`Physics.Raycast`) limitando-se apenas a objetos na `LayerMask` de portas para otimização de performance física.
- **ArmaJogador.cs:** Gerencia a leitura de botões com o Novo _InputSystem_ da Unity. Aciona arquivos dinâmicos de `AudioSource` e detecta hits via Raycast para enviar a função de dano.
- **Porta.cs / ZumbiVida.cs:** Scripts reativos. Eles não "procuram" informações ativamente (o que gastaria muito processamento), apenas reagem quando métodos públicos como `AlternarPorta()` ou `ReceberDano()` são chamados externamente pelo jogador.
- **ZumbiPerseguidor.cs:** Utiliza a biblioteca `UnityEngine.AI` para calcular o menor caminho possível até o jogador em tempo real, baseando-se no _"Bake"_ do chão azul (NavMesh Surface). Ele controla as variáveis _Bool_ e _Trigger_ enviadas para o Cérebro de Animações do modelo 3D.

## 🧠 Dúvidas e Soluções Encontradas (Diário de Desenvolvimento)

Durante a concepção e desenvolvimento deste ambiente em Realidade Virtual, alguns desafios técnicos surgiram, exigindo pesquisa e aplicação de lógicas de engenharia de software para contorná-los de forma otimizada.

### 1. Inteligência Artificial do Inimigo (Perseguição)
* **Dúvida/Desafio:** Como criar uma IA que persiga o jogador ativamente, desviando do terreno irregular e de paredes, sem causar queda de performance (frame drops) e sem que o zumbi tentasse atravessar as paredes em linha reta?
* **Solução Encontrada:** A solução ideal para manter o jogo leve no Meta Quest foi utilizar o sistema nativo de `Navigation Mesh` (NavMesh) da Unity. Em vez de usar cálculos matemáticos complexos como Raycasts contínuos ou `Vector3.MoveTowards`, o chão do cenário foi mapeado e transformado em uma superfície de navegação (`NavMesh Surface`). 
* **O Truque da Porta:** O maior problema ocorreu com a porta automática. Quando fechada, a Unity cortava o caminho azul (NavMesh), impedindo o zumbi de calcular a rota até o jogador. A solução foi aplicar um componente `NavMesh Modifier` no objeto da porta, alterando seu modo para **"Remove Object"** e marcando "Apply to children". Isso instruiu a Unity a ignorar a porta no cálculo do mapa de navegação. Assim, o zumbi tenta passar pelo vão livremente, sendo bloqueado apenas fisicamente quando a porta está fechada, criando um efeito extremamente natural.

### 2. Sistema de Animação e Sincronia
* **Dúvida/Desafio:** Como integrar um asset de modelo 3D externo e sincronizar as animações (ficar parado, caminhar e morrer) de forma fluida com a Inteligência Artificial e com o sistema de vida, sem gerar "Glitches" (como o corpo deslizando pelo chão após morrer)?
* **Solução Encontrada:** Ao importar o modelo 3D do zumbi, ele inicialmente perdeu as texturas devido à diferença entre os sistemas de renderização. A primeira solução foi utilizar o `Render Pipeline Converter` para atualizar os materiais para a **URP (Universal Render Pipeline)**. 
* Em seguida, foi estruturada uma Máquina de Estados (State Machine) através do `Animator Controller` ("CerebroZumbi"). Foram definidos dois parâmetros cruciais:
  1. Um `Bool (isWalking)`: Controlado pelo script `ZumbiPerseguidor`. O código lê a velocidade vetorial do motor de física do inimigo (`agente.velocity.magnitude`). Se a velocidade for maior que um valor mínimo (0.1f), a animação de caminhada é ativada. Ao esbarrar na porta ou alcançar o jogador (velocidade zero), a animação retorna dinamicamente para o *Idle* (Parado).
  2. Um `Trigger (morreu)`: Acionado pelo script `ZumbiVida`. O grande trunfo aqui foi a ordem de execução do código de morte. Para evitar bugs físicos, ao receber o terceiro tiro, o script executa 3 passos simultâneos: ativa a animação de queda, desliga instantaneamente o `NavMeshAgent` (cortando o "motor" do inimigo) e desliga o `CapsuleCollider` (para que o jogador possa andar sobre o corpo derrotado). O corpo é então limpo da memória via `Destroy(gameObject, 4f)` para salvar recursos do headset VR.
