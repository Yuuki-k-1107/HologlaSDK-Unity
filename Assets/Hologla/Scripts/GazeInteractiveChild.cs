using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


namespace Hologla{

    /// <summary>
    /// 親階層にGazeInteractiveコンポーネントがある場合、その各イベントを呼ぶ.
    /// イベントを呼ぶための関数はIGazeInteractインターフェースとして取得して呼ばれる.
    /// </summary>
    public class GazeInteractiveChild : MonoBehaviour, IGazeInteract
	{
		[SerializeField]private IGazeInteract parentGazeInteractive = null;

		private void Awake( )
		{
			if( null == parentGazeInteractive ){
				parentGazeInteractive = transform.parent.GetComponent<IGazeInteract>( );
			}

			return;
		}

        /// <summary>
		/// クリック（タップ）されたときに親のOnClick()を呼び出す.
		/// </summary>
        public void OnClick(ClickType clickType)
		{
			if( null != parentGazeInteractive ){
				parentGazeInteractive.OnClick(clickType);
			}
			return;
		}

        /// <summary>
        ///  選択が解除されたときに親のOnDeselect()を呼び出す.
        /// </summary>
        public void OnDeselect( )
		{
			if( null != parentGazeInteractive ){
				parentGazeInteractive.OnDeselect( );
			}
			return;
		}

        /// <summary>
        /// 選択されたときに親のOnSelect()を呼び出す.
        /// </summary>
        public void OnSelect( )
		{
			if( null != parentGazeInteractive ){
				parentGazeInteractive.OnSelect( );
			}
			return;
		}
	}

}
