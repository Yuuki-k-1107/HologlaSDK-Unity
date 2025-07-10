using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hologla{
	/// <summary>
	/// Hologlaにおいて、視点で入力を行うためのスクリプト。
	/// </summary>
	public class GazeInput : MonoBehaviour {

		[SerializeField]private GameObject gazeObject = null ;

		[SerializeField]
		private GameObject cursorObject = null ;

		[Tooltip("目からカーソル（白い球）の距離（メートル）")]
		[SerializeField]
		private float defaultCursorDistanceMeter = 2.0f ;

		// カーソルが衝突するレイヤーマスク.
		[SerializeField]private LayerMask targetLayerMask = (int)0x7FFFFFFF;
        // カーソルが衝突する最大距離.
        [SerializeField]private float targetMaxDistanceMeter = 10.0f;

		public IGazeInteract currentSelectObject{ get; private set; } = null;

		void Start( )
		{
			if( null == gazeObject ){
				gazeObject = gameObject;
			}

			return;
		}
	
		void Update( ){
		
			RaycastHit raycastHit ;
			Vector3 cursorPos ;
            // カーソル位置をdefaultCursorDistanceMeterで指定した距離前方に位置させる。
            cursorPos = gazeObject.transform.position + (gazeObject.transform.forward * defaultCursorDistanceMeter);
			if( true == Physics.Raycast(gazeObject.transform.position, gazeObject.transform.forward, out raycastHit, targetMaxDistanceMeter, targetLayerMask) ){
				IGazeInteract gazeInteract ;

				gazeInteract = raycastHit.collider.GetComponent<IGazeInteract>( );
				if( null != currentSelectObject && gazeInteract != currentSelectObject ){
					currentSelectObject.OnDeselect( );
					currentSelectObject = null;
				}
				if( null != gazeInteract && gazeInteract != currentSelectObject ){
					currentSelectObject = gazeInteract;
					currentSelectObject.OnSelect( );
				}
				cursorPos = raycastHit.point;
			}
			else if( null != currentSelectObject ){
				currentSelectObject.OnDeselect( );
				currentSelectObject = null;
			}

			if( null != cursorObject ){
				cursorObject.transform.position = cursorPos;
			}

			return;
		}

        //以下の関数群は入力操作時に外から呼び出せる関数.

        /// <summary>
        /// 左タップしたときに呼び出される関数を定義している。
        /// </summary>
        public void InputLeftEvent( )
		{
			if( null != currentSelectObject ){
				currentSelectObject.OnClick(ClickType.LeftClick);
			}

			return;
		}
        /// <summary>
        /// 右タップしたときに呼び出される関数を定義している。
        /// </summary>
        public void InputRightEvent( )
		{
			if( null != currentSelectObject ){
				currentSelectObject.OnClick(ClickType.RightClick);
			}

			return;
		}
		/// <summary>
		/// 左右同時にタップしたときに呼び出される関数を定義している。
		/// </summary>
		public void InputLeftAndRightEvent( )
		{
			if( null != currentSelectObject ){
				currentSelectObject.OnClick(ClickType.LeftAndRightClick);
			}

			return;
		}

		/// <summary>
		/// 何らかのオブジェクトが選択されているか？
		/// </summary>
		/// <returns>オブジェクトが選択されている場合は真。</returns>
		public bool IsSelectObject( )
		{
			return (null != currentSelectObject);
		}

	}
}
