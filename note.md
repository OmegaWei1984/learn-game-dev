## 基础

### 游戏对象

- `GameObject`
  - 场景中所有实体的基类，组件的容器
- `Component` 基类以及子类（比如 Transform、Reander、 MonoBehaviour 等）
  - 加在 `GameObject` 上的各种组件


`GameObject` 可以通过 `GameObject.CreatePrimitive` 函数创建各种基元（PrimitiveType），这样就可以通过代码生成各类 `GameObject`。

`PrimitiveType` 包含：球体 `Sphere`、胶囊体 `Capsule`、圆柱体 `Cylinder`、立方体 `Cube`、平面 `Plane`、四边形 `Quad`。

### 游戏循环中的行为

游戏引擎毫不意外地也是一个大的 `for` 循环，包含了很多事件节点，这些属于 `MonoBehaviour` 组件。

具体细节和先后顺序可以查阅 [MonoBehaviour](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html) 和 [ExecutionOrder](https://docs.unity3d.com/Manual/ExecutionOrder.html)。

#### 一些常用 MonoBehaviour API

|事件|作用|
|:--|:--|
|Awake|脚本实例构造时|
|FixedUpdate|每个循环（每帧，帧速率独立），物理引擎进行调用，适用于物理相关的操作|
|LateUpdate|每个循环（每帧），当处于活动状态时|
|OnDisable|当行为被禁用时|
|OnEnable|当对象启用并处于活动状态时|
|OnGUI|游戏循环每次渲染场景时|
|Start|第一次循详细文档环|
|Update|每个循环（每帧），游戏循环进行调用，适用于处理业务逻辑相关的操作|

### Instantiate

通过代码使用 `Object.Instantiate` 方法可以复制游戏对象、预制体。

`Object` 是 Unity 中对象的基类，`GameObject` 是场景中实体的基类。

```c#
// 通过 Instantiate 大量复制预制体

using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
        }
    }
}
```

### Renderer

`Renderer`（渲染器）组件使对象在屏幕被渲染出来。

```c#
// 通过渲染器获取游戏对象的尺寸
Renderer renderer = gameObject.GetComponent<Renderer>();
Vector3 size = renderer.bounds.size;
float width = size.x;  // 长
float height = size.y; // 高
float depth = size.z;  // 宽
```