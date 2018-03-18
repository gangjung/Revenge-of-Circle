using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void init()
    {
        /* Todo
         + 미리 총알들을 Pooling해 놓을 수 있는 로딩스크립트를 만들자.
         + 만드는 가장 큰 이유는, 3번째 보스의 '디플레이션 월드'에서 총알이 엄청 필요한데, 미리 생성해놓지 않으면 심각한 프레임 드랍이 발생한다.
         + 그것 이외에도 미리 할 수 있는 것들은 미리 해두자.
         + instance 정보를 가져와서 만들면 될 것 같은데, 그것을 얻어서 내부를 지정하려면, 다른 오브젝트들이 제대로 생성이 되었어야 한다.
           그렇지 않으면, instance를 읽어와도 제대로된 값을 전달해줄 수 없다.
         + 일단... 지금 생각나는 방법은 time을 이용하여, 1초마다던, 특정 시간 마다 오브젝트가 생성되었는지 확인해서 생성되었으면, 미리 처리해줄 수 있도록 한다.
         + 그렇게 하기 위해서는, Enum을 추가하여(생성중, 생성됨) 오브젝트를 제대로 확인해두는 것이 좋다.
         + 지금 고민인 것이, 스크립트 상호 연동인데, Loding에서 Pool의 instance에 접근해서 CreateObject를 하는게 좋을까, Loding 말고 그냥 Pool에서 생성되면 미리 만드는게 좋을까?
           고민인 이유는, 전자는 Pool스크립트가 잘못되면 Loding 스크립트에도 문제가 발생할 수 있는 반면, 후자는 그럴 일이 없으나 처리가... 복잡할지도??? 아직 안해봤지만서도 ㅇㅇ
         + 일단 지금은 Loding을 만들어서 하려고한다.
           

        */
    }
}
