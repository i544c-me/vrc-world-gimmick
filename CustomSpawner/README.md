# Custom Spawner

ユーザーごとにスポーン位置を設定するためのスクリプト。


## 使い方

- `SpawnPosition.cs`
    - 指定したいユーザー分だけGameObjectを作り、それぞれにこのスクリプトをアタッチする
    - ユーザー名を設定しておくと、そのユーザーはそのGameObjectの位置にスポーンするようになる
- `SpawnManager.cs`
    - シーンに1つだけ置く
    - Positionsのところに、作成しておいたSpawnPositionのGameObjectを設定する
        - GameObjectを複数選択して、SpawnPositionsの丁度文字の所にドラッグアンドドロップすると一気に登録できる