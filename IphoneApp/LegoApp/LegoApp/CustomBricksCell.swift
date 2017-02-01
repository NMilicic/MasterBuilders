//
//  CustomViewCell.swift
//  LegoApp
//
//  Created by Helena Tamburić on 21/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit
import Alamofire
import SVProgressHUD
import Unbox

class CustomBricksCell: UITableViewCell {
    
    
    
    
    public enum HTTPMethod: String {
        case options = "OPTIONS"
        case get     = "GET"
        case head    = "HEAD"
        case post    = "POST"
        case put     = "PUT"
        case patch   = "PATCH"
        case delete  = "DELETE"
        case trace   = "TRACE"
        case connect = "CONNECT"
    }
    
    @IBOutlet weak var id: UILabel!
    @IBOutlet weak var name: UILabel!
    @IBOutlet weak var category: UILabel!
   
    
    @IBOutlet weak var photoB: UIImageView!
    
        override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }
    
    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)
        
        // Configure the view for the selected state
        
    }
    
}
